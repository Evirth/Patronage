using System;
using System.IO;

namespace Task2
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
            
            try
            {
                Task2 files = new Task2();
                files.GetFiles(args.Length > 0 ? args[0] : appDir);
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
    }
}
