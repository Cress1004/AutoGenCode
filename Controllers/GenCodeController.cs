using AutoGenCode.Models;
using AutoGenCode.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoGenCode.Controllers
{
    public class GenCodeController : Controller
    {
        private readonly ElementRepository _elementRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GenCodeController(
            ElementRepository elementRepository,
            IWebHostEnvironment webHostEnvironment
        )
        {
            _elementRepository = elementRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenCode(bool isSuccess = false, int elementId = 0, string elementName = "")
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ElementId = elementId;
            ViewBag.ElementName = elementName;
            return View();
        }

        [HttpPost]
        public IActionResult GenCode(int Id)
        {
                if (Id != 0)
                {
                    var element = _elementRepository.GetElementById(Id).Result;
                    string readFilePath = "wwwroot\\code\\template.html";
                    string writeFilePath = CreateNewFile(readFilePath, element);
                    return RedirectToAction(nameof(GenCode), new { isSuccess = true, elementId = Id, elementName = element.TagName });
            }
            return View();
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "code\\result\\") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }

        private string CreateNewFile(string readFilePath, ElementModel element)
        {
            string tagName = element.TagName;
            string writeFilePath = "wwwroot\\code\\result\\" + tagName + "Element.html";
            string content = "<" + tagName + ">" + "<" + tagName + "/>";
            try
            {
                StreamReader sr = new StreamReader(readFilePath);
                string path = Path.Combine(_webHostEnvironment.WebRootPath, writeFilePath);
                StreamWriter sw = new StreamWriter(writeFilePath);
                string line = sr.ReadLine();
                while (line != null)
                {
                    if (line.Length == 0)
                    {
                        sw.WriteLine(content);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();
                return writeFilePath;
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }
            return null;
        }
    }
}
