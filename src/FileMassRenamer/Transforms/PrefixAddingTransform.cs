using System.IO;

namespace FileMassRenamer.Transforms
{
    public class PrefixAddingTransform : ITransform
    {
        public string Prefix { get; set; } = "";
        public string Execute(string filenameWithoutExtension, string fileExtension, FileInfo file, TransformContext context)
        {
            return Prefix + filenameWithoutExtension;
        }

        public override string ToString()
        {
            return nameof(PrefixAddingTransform) + $" ({Prefix})";
        }
    }
}