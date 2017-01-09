using System.IO;
using Xunit;

namespace Task2.Tests
{
    public class GetFilesTests
    {
        public string DefaultPath = "C:\\Program Files\\";

        public Task2 Execute()
        {
            Task2 testTask2 = new Task2();
            testTask2.GetFiles(DefaultPath);
            return testTask2;
        }
        
        [Fact]
        public void MainPathPropertySameAsGivenParameterTest()
        {
            Task2 testTask2 = Execute();
            Assert.Equal(testTask2.MainPath, DefaultPath);
        }

        [Fact]
        public void MainDirPropertySetAndCorrectTest()
        {
            Task2 testTask2 = Execute();
            Assert.NotNull(testTask2.MainDir);
            Assert.Equal(testTask2.MainDir.FullName, DefaultPath);
        }

        [Fact]
        public void DirsPropertySetAndCorrectTest()
        {
            Task2 testTask2 = Execute();
            Assert.NotNull(testTask2.Dirs);
            foreach (var dir in testTask2.Dirs)
            {
                Assert.Contains(DefaultPath, dir.FullName);
            }
        }

        [Fact]
        public void FilesPropertySetAndCorrectTest()
        {
            Task2 testTask2 = Execute();
            Assert.NotNull(testTask2.Files);
            foreach (var file in testTask2.Files)
            {
                Assert.Contains(DefaultPath, file.FullName);
            }
        }
    }

    public class GetDataTests
    {
        public string DefaultPath = "C:\\Windows\\notepad.exe";

        public FileSystem Execute()
        {
            Task2 testTask2 = new Task2();
            FileSystem testData = testTask2.GetData(DefaultPath);
            return testData;
        }

        [Fact]
        public void FileExistsTest()
        {
            FileSystem testData = Execute();
            Assert.True(testData.Exists);
        }

        [Fact]
        public void FileNameCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.Name, new FileInfo(DefaultPath).Name);
        }

        [Fact]
        public void FilePathCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.Path, new FileInfo(DefaultPath).FullName);
        }

        [Fact]
        public void FileSizeCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.Size, new FileInfo(DefaultPath).Length);
        }

        [Fact]
        public void FileExtensionCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.Extension, new FileInfo(DefaultPath).Extension);
        }

        [Fact]
        public void FileParentDirCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.ParentDir.FullName, new FileInfo(DefaultPath).Directory.FullName);
        }

        [Fact]
        public void FileCreationTimeCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.CreationTime, new FileInfo(DefaultPath).CreationTime);
        }

        [Fact]
        public void FileLastAccessTimeCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.LastAccessTime, new FileInfo(DefaultPath).LastAccessTime);
        }

        [Fact]
        public void FileLastWriteTimeCorrectTest()
        {
            FileSystem testData = Execute();
            Assert.Equal(testData.LastWriteTime, new FileInfo(DefaultPath).LastWriteTime);
        }
    }
}
