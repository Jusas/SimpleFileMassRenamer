using System.Collections.Generic;

namespace FileMassRenamer.Transforms
{
    public class TransformContext
    {
        public IReadOnlyList<RenameResult> Transformed { get; }

        public TransformContext(List<RenameResult> transformList)
        {
            Transformed = transformList;
        }
    }
}