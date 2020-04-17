using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FileMassRenamer.Services;
using FileMassRenamer.Transforms;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FileMassRenamer.Tests
{
    [TestClass]
    public class RenameServiceTests
    {

        private List<string> _filenames;
        private string _logFilename;

        private void GenerateTestFiles()
        {
            _filenames = new List<string>();
            var testFileDir = $"RenameServiceTestDir-{Guid.NewGuid().ToString()}";
            var testFileSubDir = "Sub";
            var tempPath = Path.GetTempPath();

            var filesToCreate = Enumerable.Range(0, 2)
                .Select(x => Path.Combine(tempPath, testFileDir, $"UnitTestFile_{x}.txt"));
            var subdirFilesToCreate = Enumerable.Range(0, 4)
                .Select(x => Path.Combine(tempPath, testFileDir, testFileSubDir, $"UnitTestFile_{x}.txt"));

            _filenames = filesToCreate.ToList();
            _filenames.AddRange(subdirFilesToCreate);

            foreach (var filename in _filenames)
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filename));
                File.Create(filename).Dispose();
            }

            _logFilename = Path.Combine(tempPath, testFileDir, "rename_log.txt");
        }

        private void DeleteTestFiles()
        {
            foreach (var file in _filenames)
            {
                File.Delete(file);
            }
            if(File.Exists(_logFilename))
                File.Delete(_logFilename);
        }

        [TestInitialize]
        public void Setup()
        {
            GenerateTestFiles();
        }

        [TestCleanup]
        public void TearDown()
        {
            DeleteTestFiles();
        }

        [TestMethod]
        public void UniqueFilenameTransform_Should_rename_files_to_be_unique()
        {
            var service = new RenameService();
            service.SetTransformActive<UniqueFilenameTransform>(true);

            var previewResults = service.PreviewTransformedFilenames(_filenames);

            Assert.AreEqual(6, previewResults.Count);
            Assert.IsNotNull(previewResults.FirstOrDefault(x => x.FilenameWithoutExtension == "UnitTestFile_0"));
            Assert.IsNotNull(previewResults.FirstOrDefault(x => x.FilenameWithoutExtension == "UnitTestFile_0_2"));
            Assert.IsNotNull(previewResults.FirstOrDefault(x => x.FilenameWithoutExtension == "UnitTestFile_1"));
            Assert.IsNotNull(previewResults.FirstOrDefault(x => x.FilenameWithoutExtension == "UnitTestFile_1_2"));
            Assert.IsNotNull(previewResults.FirstOrDefault(x => x.FilenameWithoutExtension == "UnitTestFile_2"));
            Assert.IsNotNull(previewResults.FirstOrDefault(x => x.FilenameWithoutExtension == "UnitTestFile_3"));
        }

        [TestMethod]
        public void DateTimeAppenderTransform_Should_rename_files_to_end_with_year()
        {
            var service = new RenameService();
            service.SetTransformActive<DateTimeAppenderTransform>(true);
            service.GetTransform<DateTimeAppenderTransform>().DateTimeFormat = "yyyy";

            var previewResults = service.PreviewTransformedFilenames(_filenames);

            var year = DateTime.Now.Year;
            Assert.AreEqual(6, previewResults.Count);
            Assert.AreEqual(2, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_0" + year));
            Assert.AreEqual(2, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_1" + year));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_2" + year));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_3" + year));
        }

        [TestMethod]
        public void SuffixAddingTransform_Should_rename_files_to_end_with_suffix()
        {
            var service = new RenameService();
            service.SetTransformActive<SuffixAddingTransform>(true);
            service.GetTransform<SuffixAddingTransform>().Suffix = "_suffix";

            var previewResults = service.PreviewTransformedFilenames(_filenames);

            Assert.AreEqual(6, previewResults.Count);
            Assert.AreEqual(2, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_0_suffix"));
            Assert.AreEqual(2, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_1_suffix"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_2_suffix"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "UnitTestFile_3_suffix"));
        }

        [TestMethod]
        public void PrefixAddingTransform_Should_rename_files_to_start_with_prefix()
        {
            var service = new RenameService();
            service.SetTransformActive<PrefixAddingTransform>(true);
            service.GetTransform<PrefixAddingTransform>().Prefix = "prefix_";

            var previewResults = service.PreviewTransformedFilenames(_filenames);

            Assert.AreEqual(6, previewResults.Count);
            Assert.AreEqual(2, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_0"));
            Assert.AreEqual(2, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_1"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_2"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_3"));
        }

        [TestMethod]
        public void Should_perform_full_stack_of_transforms_correctly()
        {
            var service = new RenameService();
            service.SetTransformActive<DateTimeAppenderTransform>(true);
            service.SetTransformActive<PrefixAddingTransform>(true);
            service.SetTransformActive<SuffixAddingTransform>(true);
            service.SetTransformActive<UniqueFilenameTransform>(true);

            service.GetTransform<PrefixAddingTransform>().Prefix = "prefix_";
            service.GetTransform<SuffixAddingTransform>().Suffix = "_suffix";
            service.GetTransform<DateTimeAppenderTransform>().DateTimeFormat = "_yyyy-MM-dd";

            var expectedDateTime = DateTime.Now.ToString("_yyyy-MM-dd");

            var previewResults = service.PreviewTransformedFilenames(_filenames);

            Assert.AreEqual(6, previewResults.Count);
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_0" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_1" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_2" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_3" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_0" + expectedDateTime + "_suffix_2"));
            Assert.AreEqual(1, previewResults.Count(x => x.FilenameWithoutExtension == "prefix_UnitTestFile_1" + expectedDateTime + "_suffix_2"));
        }

        [TestMethod]
        public void Should_execute_full_stack_transform_rename_correctly_and_write_a_log()
        {
            var service = new RenameService();
            service.SetTransformActive<DateTimeAppenderTransform>(true);
            service.SetTransformActive<PrefixAddingTransform>(true);
            service.SetTransformActive<SuffixAddingTransform>(true);
            service.SetTransformActive<UniqueFilenameTransform>(true);

            service.GetTransform<PrefixAddingTransform>().Prefix = "prefix_";
            service.GetTransform<SuffixAddingTransform>().Suffix = "_suffix";
            service.GetTransform<DateTimeAppenderTransform>().DateTimeFormat = "_yyyy-MM-dd";

            var expectedDateTime = DateTime.Now.ToString("_yyyy-MM-dd");

            var executionResults = service.ExecuteRenames(_filenames.Select(x => (x, true)).ToList(), _logFilename);

            Assert.AreEqual(true, executionResults.Success);
            Assert.IsTrue(executionResults.ExecutionLog.Length > 0);

            Assert.AreEqual(6, executionResults.FileRenameResults.Count);
            Assert.AreEqual(1, executionResults.FileRenameResults.Count(x => x.Key.FilenameWithoutExtension == "prefix_UnitTestFile_0" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, executionResults.FileRenameResults.Count(x => x.Key.FilenameWithoutExtension == "prefix_UnitTestFile_1" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, executionResults.FileRenameResults.Count(x => x.Key.FilenameWithoutExtension == "prefix_UnitTestFile_2" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, executionResults.FileRenameResults.Count(x => x.Key.FilenameWithoutExtension == "prefix_UnitTestFile_3" + expectedDateTime + "_suffix"));
            Assert.AreEqual(1, executionResults.FileRenameResults.Count(x => x.Key.FilenameWithoutExtension == "prefix_UnitTestFile_0" + expectedDateTime + "_suffix_2"));
            Assert.AreEqual(1, executionResults.FileRenameResults.Count(x => x.Key.FilenameWithoutExtension == "prefix_UnitTestFile_1" + expectedDateTime + "_suffix_2"));

            Assert.IsTrue(File.Exists(executionResults.FileRenameResults.ElementAt(0).Key.FileInfo.FullName));
            Assert.IsTrue(File.Exists(executionResults.FileRenameResults.ElementAt(1).Key.FileInfo.FullName));
            Assert.IsTrue(File.Exists(executionResults.FileRenameResults.ElementAt(2).Key.FileInfo.FullName));
            Assert.IsTrue(File.Exists(executionResults.FileRenameResults.ElementAt(3).Key.FileInfo.FullName));
            Assert.IsTrue(File.Exists(executionResults.FileRenameResults.ElementAt(4).Key.FileInfo.FullName));
            Assert.IsTrue(File.Exists(executionResults.FileRenameResults.ElementAt(5).Key.FileInfo.FullName));

            Assert.IsTrue(File.Exists(_logFilename));
        }

    }
}
