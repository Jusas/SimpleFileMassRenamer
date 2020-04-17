using System.IO;

namespace FileMassRenamer.Transforms
{
    public class RenameResult
    {
        public FileInfo FileInfo { get; set; }
        public string FilenameWithoutExtension { get; set; }
        public string FileExtension { get; set; }
    }
}