using System;
using System.IO;

namespace Task2
{
    interface IFileSystemModel
    {
        bool Exists { get; set; }
        string Name { get; set; }
        string Path { get; set; }
        long Size { get; set; }
        string Extension { get; set; }
        DirectoryInfo ParentDir { get; set; }
        DateTime CreationTime { get; set; }
        DateTime LastAccessTime { get; set; }
        DateTime LastWriteTime { get; set; }
    }

    public class FileSystem : IFileSystemModel
    {
        public bool Exists { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public DirectoryInfo ParentDir { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }

        public FileSystem(string pPath)
        {
            FileInfo file = new FileInfo(pPath);
            Exists = file.Exists;
            Name = file.Name;
            Path = file.FullName;
            Size = file.Length;
            Extension = file.Extension;
            ParentDir = file.Directory;
            CreationTime = file.CreationTime;
            LastAccessTime = file.LastAccessTime;
            LastWriteTime = file.LastWriteTime;
        }
    }
}
