using System.Collections.Generic;
using System.IO;

namespace FileMassRenamer.Utils
{
    public static class PathTools
    {
        /// <summary>
        /// Expands a list of paths (files and directories) to a flat file list,
        /// i.e. recursively explores subdirectories and enumerates their files.
        /// </summary>
        /// <param name="paths"></param>
        /// <returns></returns>
        public static List<string> ExpandToFileList(IEnumerable<string> paths)
        {
            var fileList = new List<string>();

            foreach (var path in paths)
            {
                var fileAttributes = File.GetAttributes(path);
                if (fileAttributes.HasFlag(FileAttributes.Directory))
                {
                    fileList.AddRange(Directory.GetFiles(path));
                    fileList.AddRange(ExpandToFileList(Directory.GetDirectories(path)));
                }
                else
                {
                    fileList.Add(path);
                }
            }

            return fileList;
        }


    }
}