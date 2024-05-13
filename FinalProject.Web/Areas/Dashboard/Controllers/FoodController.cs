using Business.Concrete;
using Core.Results.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FoodController : Controller
    {
        FoodManager _foodManager = new();
        FoodCategoryManager FoodCategoryManager = new();
        public IActionResult Index()
        {
            var data = _foodManager.GetFoodWithFoodCategoryId().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["FoodCategories"] = FoodCategoryManager.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            var result = _foodManager.Add(food);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["FoodCategories"] = FoodCategoryManager.GetAll().Data;

            var data = _foodManager.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Food food)
        {
            var result = _foodManager.Update(food);


            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result =_foodManager.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

    }
}
