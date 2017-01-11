using System;
using System.IO;

namespace Task2.Interfaces
{
    public interface IFileSystemModel
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
}