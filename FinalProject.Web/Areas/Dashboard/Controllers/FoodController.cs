using Business.Abstract;
using Business.Concrete;
using Core.Results.Concrete;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IFoodCategoryService _foodCategoryService;
        public FoodController(IFoodService foodService, IFoodCategoryService foodCategoryService)
        {
            _foodService = foodService;
            _foodCategoryService = foodCategoryService;
        }

        public IActionResult Index()
        {
            var data = _foodService.GetFoodWithFoodCategoryId().Data;

            return View(data);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["FoodCategories"] = _foodCategoryService.GetAll().Data;

            return View();
        }

        [HttpPost]
        public IActionResult Create(Food food)
        {
            var result = _foodService.Add(food);

            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewData["FoodCategories"] = _foodCategoryService.GetAll().Data;

            var data = _foodService.GetById(id).Data;

            return View(data);
        }

        [HttpPost]
        public IActionResult Edit(Food food)
        {
            var result = _foodService.Update(food);


            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(food);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var result = _foodService.Delete(id);
            if (result.IsSuccess)
            {
                return RedirectToAction("Index");
            }
            return View(result);
        }

    }
}
