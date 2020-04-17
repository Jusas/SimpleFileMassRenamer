using System.IO;

namespace FileMassRenamer.Transforms
{
    public class SuffixAddingTransform : ITransform
    {
        public string Suffix { get; set; }

        public string Execute(string filenameWithoutExtension, string fileExtension, FileInfo file, TransformContext context)
        {
            return filenameWithoutExtension + Suffix;
        }

        public override string ToString()
        {
            return nameof(SuffixAddingTransform) + $" ({Suffix})";
        }
    }
}