using System.IO;

namespace Task2.Interfaces
{
    public interface ITask2
    {
        string MainPath { get; set; }
        DirectoryInfo MainDir { get; set; }
        DirectoryInfo[] Dirs { get; set; }
        FileInfo[] Files { get; set; }

        void GetFiles(string pPath);
        FileSystem GetData(string pPath);
    }
}