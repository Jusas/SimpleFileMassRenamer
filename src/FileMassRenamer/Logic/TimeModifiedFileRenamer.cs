using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileMassRenamer.Logic
{
    sealed class TimeModifiedFileRenamer
    {

        public TimeModifiedFileRenamer()
        {
            
        }

        public enum Reason
        {
            Ok,
            AlreadyRenamed,
            Exception
        }

        public (bool didRename, string newFilename, Reason reason, string reasonText) RenameFile(string filename)
        {
            try
            {
                FileInfo fileInfo = new FileInfo(filename);
                var timestamp = fileInfo.LastWriteTime.ToString("_yyyyMMddTHHmmss");

                var filenameMainPart = Path.GetFileNameWithoutExtension(filename);
                var filenameDirectory = fileInfo.DirectoryName ?? "";
                var filenameExt = fileInfo.Extension;

                if (filenameMainPart.EndsWith(timestamp))
                {
                    return (false, filename, Reason.AlreadyRenamed, "Already renamed");
                }

                var newFilename = Path.Combine(filenameDirectory, filenameMainPart + timestamp + filenameExt);
                fileInfo.MoveTo(newFilename);

                return (true, newFilename, Reason.Ok, "Renamed ok");
            }
            catch (Exception e)
            {
                return (false, filename, Reason.Exception, e.Message);
            }

        }
    }
}
