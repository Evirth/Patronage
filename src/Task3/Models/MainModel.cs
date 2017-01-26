using System;

namespace Task3.Models
{
    public class MainModel
    {
        public bool Exists { get; set; }
        public string Name { get; set; }
        public string Path { get; set; }
        public long Size { get; set; }
        public string Extension { get; set; }
        public string ParentDir { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public DateTime LastWriteTime { get; set; }
    }
}
