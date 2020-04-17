using System;
using System.IO;
using System.Linq;

namespace FileMassRenamer.Transforms
{
    public class UniqueFilenameTransform : ITransform
    {
        public string Execute(string filenameWithoutExtension, string fileExtension, FileInfo file, TransformContext context)
        {
            var uniqueFilename = filenameWithoutExtension;

            var i = 1;
            while(context.Transformed.Any(x =>
                x.FilenameWithoutExtension.Equals(uniqueFilename, StringComparison.OrdinalIgnoreCase) &&
                x.FileExtension.Equals(fileExtension)))
            {
                uniqueFilename = filenameWithoutExtension + $"_{++i}";
            }

            return uniqueFilename;
        }

        public override string ToString()
        {
            return nameof(UniqueFilenameTransform);
        }
    }
}