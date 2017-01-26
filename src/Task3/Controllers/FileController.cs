using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace Task3.Controllers
{
    public class FileController : Controller
    {
        public string Index(string path)
        {
            Task2.Task2 file = new Task2.Task2();
            Task2.FileSystem fileSystem;

            try
            {
                fileSystem = file.GetData(path);
            }
            catch (Exception e)
            {
                return e.Message;
            }
            
            StringBuilder fileSystemString = new StringBuilder();
            fileSystemString.AppendLine("Exists: \t\t" + fileSystem.Exists);
            fileSystemString.AppendLine("Name: \t\t\t" + fileSystem.Name);
            fileSystemString.AppendLine("Size: \t\t\t" + fileSystem.Size + " B");
            fileSystemString.AppendLine("Extension: \t\t" + fileSystem.Extension);
            fileSystemString.AppendLine("Path: \t\t\t" + fileSystem.Path);
            fileSystemString.AppendLine("Parent Directory: \t" + fileSystem.ParentDir);
            fileSystemString.AppendLine("Creation Time: \t\t" + fileSystem.CreationTime);
            fileSystemString.AppendLine("Last Acces Time: \t" + fileSystem.LastAccessTime);
            fileSystemString.AppendLine("Last Write Time: \t" + fileSystem.LastWriteTime);

            return fileSystemString.ToString();
        }
    }
}
