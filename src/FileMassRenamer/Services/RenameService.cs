using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using FileMassRenamer.Logic;
using FileMassRenamer.Transforms;

namespace FileMassRenamer.Services
{
    public class RenameService
    {

        private Dictionary<ITransform, bool> TransformStack { get; } = new Dictionary<ITransform, bool>();

        public RenameService()
        {
            TransformStack.Add(new DateTimeAppenderTransform(), false);
            TransformStack.Add(new PrefixAddingTransform(), false);
            TransformStack.Add(new SuffixAddingTransform(), false);
            TransformStack.Add(new UniqueFilenameTransform(), false);
        }

        public void SetTransformActive<T>(bool active) where T:ITransform
        {
            var transform = TransformStack.First(x => x.Key.GetType() == typeof(T)).Key;
            TransformStack[transform] = active;
        }

        public T GetTransform<T>() where T:ITransform
        {
            return (T)TransformStack.First(x => x.Key.GetType() == typeof(T)).Key;
        }

        public List<RenameResult> PreviewTransformedFilenames(IEnumerable<string> filenames)
        {
            return ExecuteTransformStack(filenames, null);
        }

        private List<RenameResult> ExecuteTransformStack(IEnumerable<string> filenames, Action<Exception, ITransform, string> onErrorAction)
        {
            var transforms = TransformStack.Where(x => x.Value == true).Select(x => x.Key);

            var renameResults = new List<RenameResult>();
            var context = new TransformContext(renameResults);
            foreach (var filename in filenames)
            {
                var fileInfo = new FileInfo(filename);
                var filenameWithoutExtension = Path.GetFileNameWithoutExtension(filename);
                var fileExtension = Path.GetExtension(filename);

                foreach (var transform in transforms)
                {
                    try
                    {
                        filenameWithoutExtension =
                            transform.Execute(filenameWithoutExtension, fileExtension, fileInfo, context);
                    }
                    catch (Exception exception)
                    {
                        onErrorAction?.Invoke(exception, transform, filename);
                    }
                }

                renameResults.Add(new RenameResult()
                {
                    FileExtension = fileExtension,
                    FileInfo = fileInfo,
                    FilenameWithoutExtension = filenameWithoutExtension
                });
            }

            return renameResults;
        }

        private string MakeLogLine(string text)
        {
            return $"[{DateTime.Now:HH:mm:ss.fff}] " + text + "\r\n";
        }

        private void WriteLogLine(string text, Stream logStream, StringBuilder inMemoryLog)
        {
            var line = MakeLogLine(text); 
            var buf = Encoding.UTF8.GetBytes(line);
            logStream?.Write(buf, 0, buf.Length);
            inMemoryLog.Append(line);
        }

        private void LogException(Exception e, ITransform transform, string filename, Stream logStream, StringBuilder inMemoryLog)
        {
            var errorMsg = MakeLogLine($"Transform '{transform}' failed for file '{filename}': {e.Message}");
            WriteLogLine(errorMsg, logStream, inMemoryLog);
        }

        private void LogException(Exception e, Stream logStream,
            StringBuilder inMemoryLog)
        {
            var text = $"ERROR: Failed to rename the file: {e.GetType()} - {e.Message}";
            WriteLogLine(text, logStream, inMemoryLog);
        }

        private void LogText(string text, Stream logStream, StringBuilder inMemoryLog)
        {
            WriteLogLine(text, logStream, inMemoryLog);
        }

        private void LogRename(string sourceFilename, string destFilename, Stream logStream, StringBuilder inMemoryLog)
        {
            var text = $"Renaming '{sourceFilename}' \r\n                     -> '{destFilename}' ...";
            WriteLogLine(text, logStream, inMemoryLog);
        }

        public RenameExecutionResults ExecuteRenames(IList<(string filename, bool execute)> filenames, string logFilename)
        {
            bool errors = false;
            List<RenameResult> renames = null;
            StringBuilder inMemoryLog = new StringBuilder();
            var executionResults = new RenameExecutionResults();

            FileStream logStream = null;
            try
            {
                logStream = !string.IsNullOrEmpty(logFilename)
                    ? new FileStream(logFilename, FileMode.Create)
                    : null;
            }
            catch (Exception e)
            {
                inMemoryLog.Append("WARNING: FAILED TO OPEN LOG FILE FOR WRITING! LOG FILE OUTPUT NOT AVAILABLE! \r\n");
                inMemoryLog.Append($"LOGFILE STREAM OPEN ERROR: {e.GetType()} - {e.Message}");
            }
            

            using (logStream)
            {
                LogText("Executing filename transforms...", logStream, inMemoryLog);
                renames = ExecuteTransformStack(filenames.Select(x => x.filename), (e, tf, fn) =>
                {
                    LogException(e, tf, fn, logStream, inMemoryLog);
                    errors = true;
                });

                if (errors)
                    LogText("Will not perform renames since some transforms failed.", logStream, inMemoryLog);
                else
                    LogText("All transforms succeeded, proceeding to rename the files.", logStream, inMemoryLog);

                if (errors)
                {
                    return new RenameExecutionResults()
                    {
                        ExecutionLog = inMemoryLog.ToString(),
                        Success = false
                    };
                }

                for (var i = 0; i < renames.Count; i++)
                {
                    var rename = renames[i];
                    var execute = filenames[i].execute;

                    if (!execute)
                        LogText($"File '{rename.FileInfo.FullName}' was not selected for rename, skipping.", logStream, inMemoryLog);

                    try
                    {
                        if (execute)
                        {
                            var newFilename = Path.Combine(Path.GetDirectoryName(rename.FileInfo.FullName),
                                rename.FilenameWithoutExtension + rename.FileExtension);
                            LogRename(rename.FileInfo.FullName, newFilename, logStream, inMemoryLog);
                            rename.FileInfo.MoveTo(newFilename);
                        }
                        executionResults.FileRenameResults.Add(rename, true);
                    }
                    catch (Exception e)
                    {
                        LogException(e, logStream, inMemoryLog);
                        executionResults.FileRenameResults.Add(rename, false);
                    }
                }

                LogText("All filenames processed.", logStream, inMemoryLog);

                executionResults.Success = executionResults.FileRenameResults.All(x => x.Value == true);
                executionResults.ExecutionLog = inMemoryLog.ToString();
                return executionResults;
            }


        }
    }
}