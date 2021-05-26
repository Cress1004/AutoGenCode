using AutoGenCode.Data;
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
        private static Random random = new Random();
        private readonly TagRepository _tagRepository = null;
        private readonly RegionRepository _regionRepository = null;
        private readonly GenUIRepository _genUIRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public GenCodeController(
            TagRepository tagRepository,
            RegionRepository regionRepository,
            GenUIRepository genUIRepository,
            IWebHostEnvironment webHostEnvironment
        )
        {
            _tagRepository = tagRepository;
            _regionRepository = regionRepository;
            _genUIRepository = genUIRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GenRegion(bool isSuccess = false, int regionId = 0, string regionName = "")
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.RegionId = regionId;
            ViewBag.RegionName = regionName;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GenRegion(RegionModel region)
        {
            if (ModelState.IsValid)
            {
                int id = await _regionRepository.AddNewRegion(region);
                if (id > 0)
                {
                    var dateTime = DateTime.UtcNow.GetHashCode().ToString();
                    string readFilePath = "wwwroot\\code\\template.html";
                    string fileName = CreateNewRegionFile(readFilePath, region, dateTime);
                    return RedirectToAction(nameof(GenRegion), new { isSuccess = true, regionId = id, regionName = fileName });
                }
            }
            return View();
        }

        public IActionResult GenCode(bool isSuccess = false, int tagId = 0, string tagName = "")
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.TagId = tagId;
            ViewBag.TagName = tagName;
            return View();
        }

        [HttpPost]
        public IActionResult GenCode(int Id)
        {
                if (Id != 0)
                {
                    var tag = _tagRepository.GetTagById(Id).Result;
                    string readFilePath = "wwwroot\\code\\template.html";
                    string writeFilePath = CreateNewTagFile(readFilePath, tag);
                    return RedirectToAction(nameof(GenCode), new { isSuccess = true, tagId = Id, tagName = tag.TagName });
            }
            return View();
        }

        public FileResult DownloadFile(string fileName)
        {
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "code\\result\\") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);
            return File(bytes, "application/octet-stream", fileName);
        }

        private string CreateNewTagFile(string readFilePath, TagModel tag)
        {
            string fileName = tag.TagName;
            string writeFilePath = "wwwroot\\code\\result\\" + fileName + "Tag.html";
            string content = "<" + fileName + ">" + "<" + fileName + "/>";
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

        private string CreateNewRegionFile(string readFilePath, RegionModel region, string dateTime)
        {
            var tag = _tagRepository.GetTagById(region.TagId).Result;
            string tagName = tag.TagName;
            string fileName = tagName + "_" + dateTime + ".html";
            string writeFilePath = "wwwroot\\code\\result\\" + fileName;

            string attr = "<" + tagName +
                                    " height=\"" + region.Height + "\"" +
                                    " width=\"" + region.Width + "\"";
            if (tag.HasEndTag) { 
                attr += ">" + tagName + "</" + tagName + ">";
            }
            else
            {
                attr += "/>";
            }
            
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
                        sw.WriteLine(attr);
                    }
                    else
                    {
                        sw.WriteLine(line);
                    }
                    line = sr.ReadLine();
                }
                sr.Close();
                sw.Close();
                return fileName;
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
