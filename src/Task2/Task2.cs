using System;
using System.IO;

namespace Task2
{
    interface ITask2
    {
        string MainPath { get; set; }
        DirectoryInfo MainDir { get; set; }
        DirectoryInfo[] Dirs { get; set; }
        FileInfo[] Files { get; set; }

        void GetFiles(string pPath);
        FileSystem GetData(string pPath);

    }

    public class Task2 : ITask2
    {
        public string MainPath { get; set; }
        public DirectoryInfo MainDir { get; set; }
        public DirectoryInfo[] Dirs { get; set; }
        public FileInfo[] Files { get; set; }

        public void GetFiles(string pPath)
        {
            MainPath = pPath;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Name".PadLeft(42)}{"Creation Time".PadLeft(55)}");
            Console.WriteLine($"{new string('_', 100)}");

            MainDir = new DirectoryInfo(MainPath);
            Dirs = MainDir.GetDirectories("*", SearchOption.TopDirectoryOnly);
            Files = MainDir.GetFiles("*.*", SearchOption.TopDirectoryOnly);
            int charsToCut;
            foreach (DirectoryInfo dir in Dirs)
            {
                charsToCut = MainDir.FullName.LastIndexOf(Path.DirectorySeparatorChar) + 1 == MainDir.FullName.Length ?
                    MainDir.FullName.Length : MainDir.FullName.Length + 1;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{dir.FullName.Remove(0, charsToCut).PadRight(100 - dir.CreationTime.ToString().Length)}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (dir.FullName.Remove(0, MainDir.FullName.Length + 1).Length > 80)
                {
                    Console.Write($"\n{new string('^', 81)}".PadRight(79));
                }
                Console.WriteLine(dir.CreationTime);
            }

            foreach (FileInfo file in Files)
            {
                charsToCut = MainDir.FullName.LastIndexOf(Path.DirectorySeparatorChar) + 1 == MainDir.FullName.Length ?
                    MainDir.FullName.Length : MainDir.FullName.Length + 1;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{file.FullName.Remove(0, charsToCut).PadRight(100 - file.CreationTime.ToString().Length)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (file.FullName.Remove(0, MainDir.FullName.Length + 1).Length > 80)
                {
                    Console.Write($"\n{new string('^', 81)}".PadRight(79));
                }
                Console.WriteLine(file.CreationTime);
            }
        }

        public FileSystem GetData(string pPath)
        {
            return new FileSystem(pPath);
        }
    }
}
