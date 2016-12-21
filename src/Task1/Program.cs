using System;
using System.IO;

namespace Task1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string[] consoleArgs = Environment.GetCommandLineArgs();
            string appDir = null;
            if (consoleArgs[0] != null)
            {
                appDir = consoleArgs[0].Remove(consoleArgs[0].LastIndexOf(Path.DirectorySeparatorChar) + 1);
                Console.WriteLine(appDir + "\nKatalog istnieje\n");
            }
            else
            {
                Console.WriteLine("Wystąpił błąd. Nie mogę odczytać ścieżki do katalogu. Katalog nie istnieje.");
                Environment.Exit(-1);
            }

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine($"{"Name".PadLeft(42)}{"Creation Time".PadLeft(55)}");
            Console.WriteLine($"{new string('_', 100)}");

            try
            {
                ShowFiles(new DirectoryInfo(args.Length > 0 ? args[0] : appDir), "--");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("An error occurred!\n" + ex.Message);
            }
            finally
            {
                Console.ResetColor();
            }
        }

        public static void ShowFiles(DirectoryInfo pPath, string pPrefix)
        {
            DirectoryInfo[] dirs = pPath.GetDirectories();
            FileInfo[] files = pPath.GetFiles("*.*", SearchOption.TopDirectoryOnly);

            foreach (DirectoryInfo dir in dirs)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"{pPrefix}{dir.Name.PadRight(100 - pPrefix.Length - dir.CreationTime.ToString().Length)}");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                if (pPrefix.Length + dir.Name.Length > 80)
                {
                    Console.Write("\n".PadRight(pPrefix.Length - 2) + $"{new string('^', 81 - pPrefix.Length + 2)}".PadRight(79));
                }
                Console.WriteLine(dir.CreationTime);
                ShowFiles(dir, $"{"|--".PadLeft(pPrefix.Length + 3)}");
            }

            foreach (FileInfo file in files)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($"{pPrefix.PadLeft(pPrefix.Length)}{file.Name.PadRight(100 - pPrefix.Length - file.CreationTime.ToString().Length)}");
                Console.ForegroundColor = ConsoleColor.Gray;
                if (pPrefix.Length + file.Name.Length > 80)
                {
                    Console.Write("\n".PadRight(pPrefix.Length - 2) + $"{new string('^', 81 - pPrefix.Length + 2)}".PadRight(79));
                }
                Console.WriteLine(file.CreationTime);
            }
        }
    }
}
