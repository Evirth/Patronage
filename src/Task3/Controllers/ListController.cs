using System;
using System.IO;
using Microsoft.AspNetCore.Mvc;

namespace Task3.Controllers
{
    public class ListController : Controller
    {
        public static Task2.Task2 Files { get; set; }

        [Route("")]
        public IActionResult Index(string path)
        {
            Files = new Task2.Task2();
            if (!string.IsNullOrWhiteSpace(path))
            {
                if (Directory.Exists(path))
                {
                    try
                    {
                        Files.GetFiles(path);
                    }
                    catch (Exception e)
                    {
                        ViewBag.ExepctionMsg = e.Message;
                        return View();
                    }
                }
                else
                {
                    ViewBag.ExepctionMsg = "Directory doesn't exist.";
                }
            }
            else
            {
                Files.GetFiles(Directory.GetCurrentDirectory());
            }

            return View();
        }
    }
}
