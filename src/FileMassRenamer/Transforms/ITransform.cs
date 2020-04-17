using System.IO;

namespace FileMassRenamer.Transforms
{
    public interface ITransform
    {
        string Execute(string filenameWithoutExtension, string fileExtension, FileInfo file, TransformContext context);
    }
}