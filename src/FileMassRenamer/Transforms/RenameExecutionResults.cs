using System.Collections.Generic;

namespace FileMassRenamer.Transforms
{
    public class RenameExecutionResults
    {
        public Dictionary<RenameResult, bool> FileRenameResults { get; set; } = new Dictionary<RenameResult, bool>();
        public bool Success { get; set; }
        public string ExecutionLog { get; set; }
    }
}