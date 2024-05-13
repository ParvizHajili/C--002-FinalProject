using Business.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FoodCategoryController : Controller
    {
        FoodCategoryManager _foodCategoryManager = new();

        public IActionResult Index()
        {
            var data = _foodCategoryManager.GetAll().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(FoodCategory foodCategory)
        {
            var result = _foodCategoryManager.Add(foodCategory);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }

            return View(foodCategory);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var data = _foodCategoryManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(FoodCategory foodCategory)
        {
            var result = _foodCategoryManager.Update(foodCategory);

            if (result.IsSuccess) return RedirectToAction("Index");

            return View(foodCategory);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _foodCategoryManager.Delete(id);
            if(result.IsSuccess)
                return RedirectToAction("Index");

            return View(result);
        }
    }
}
