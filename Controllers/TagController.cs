using AutoGenCode.Models;
using AutoGenCode.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Controllers
{
    public class TagController : Controller
    {
        private readonly TagRepository _tagRepository = null;
        public TagController(TagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ViewResult> GetTags()
        {
            var data = await _tagRepository.GetTags();
            return View(data);
        }
        public ViewResult AddNewTag(bool isSuccess = false, int tagId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.TagId = tagId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewTag(TagModel tag)
        {
            if (ModelState.IsValid)
            {
                int id = await _tagRepository.AddNewTag(tag);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewTag), new { isSuccess = true, tagId = id });
                }
            }
            return View();
        }
    }
}
