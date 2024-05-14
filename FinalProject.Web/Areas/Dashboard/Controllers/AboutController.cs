using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class AboutController : Controller
    {
        AboutManager _aboutService = new();

        public IActionResult Index()
        {
            var data = _aboutService.GetAll().Data;

            ViewBag.ShowButton = data.Count() == 0;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(About about)
        {
            var result = _aboutService.Add(about);
            if (result.IsSuccess) return RedirectToAction("Index");

            return View(about);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _aboutService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(About about)
        {
            var result = _aboutService.Update(about);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(about);
        }
    }
}
