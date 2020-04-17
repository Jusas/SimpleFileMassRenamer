using System;
using System.IO;
using FileMassRenamer.Logic;

namespace FileMassRenamer.Transforms
{
    public class DateTimeAppenderTransform : ITransform
    {
        public string DateTimeFormat { get; set; } = "yyyy-MM-ddTHHmm";

        public bool IsValid
        {
            get
            {
                try
                {
                    DateTime.UtcNow.ToString(DateTimeFormat);
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
        }

        public string Execute(string filenameWithoutExtension, string fileExtension, FileInfo file, TransformContext context)
        {
            var datePart = file.LastWriteTime.ToString(DateTimeFormat);
            return filenameWithoutExtension + datePart;
        }

        public override string ToString()
        {
            return nameof(DateTimeAppenderTransform) + $" ({DateTimeFormat})";
        }
    }
}