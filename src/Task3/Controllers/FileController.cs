using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Task3.Models;

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
            catch (ArgumentNullException)
            {
                return "Use '/File?path=...' to select a file which metadata you want to print.";
            }
            catch (Exception e)
            {
                return e.Message;
            }

            var modifiedForJson = new MainModel
            {
                Exists = fileSystem.Exists,
                Name = fileSystem.Name,
                Path = fileSystem.Path,
                Size = fileSystem.Size,
                Extension = fileSystem.Extension,
                ParentDir = fileSystem.ParentDir.FullName,      //Changed to string from DirectoryInfo type because of Json exception
                CreationTime = fileSystem.CreationTime,
                LastWriteTime = fileSystem.LastWriteTime,
                LastAccessTime = fileSystem.LastAccessTime
            };

            return JsonConvert.SerializeObject(modifiedForJson, Formatting.Indented);
        }
    }
}
