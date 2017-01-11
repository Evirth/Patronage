using System;
using System.IO;
using Task2.Interfaces;

namespace Task2
{
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
