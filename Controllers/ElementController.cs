using AutoGenCode.Models;
using AutoGenCode.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoGenCode.Controllers
{
    public class ElementController : Controller
    {
        private readonly ElementRepository _elementRepository = null;
        public ElementController(ElementRepository elementRepository)
        {
            _elementRepository = elementRepository;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<ViewResult> GetElements()
        {
            var data = await _elementRepository.GetElements();
            return View(data);
        }
        public ViewResult AddNewElement(bool isSuccess = false, int elementId = 0)
        {
            ViewBag.IsSuccess = isSuccess;
            ViewBag.ElementId = elementId;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddNewElement(ElementModel element)
        {
            if (ModelState.IsValid)
            {
                int id = await _elementRepository.AddNewElement(element);
                if (id > 0)
                {
                    return RedirectToAction(nameof(AddNewElement), new { isSuccess = true, elementId = id });
                }
            }
            return View();
        }
    }
}
