using Business.Abstract;
using Core.Extenstion;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    public class FoodController : Controller
    {
        private readonly IFoodService _foodService;
        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IWebHostEnvironment _env;
        public FoodController(IFoodService foodService, IFoodCategoryService foodCategoryService, IWebHostEnvironment webHostEnvironment)
        {
            _foodService = foodService;
            _foodCategoryService = foodCategoryService;
            _env = webHostEnvironment;
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
        public IActionResult Create(Food food,IFormFile photoUrl)
        {
            var result = _foodService.Add(food,photoUrl,_env.WebRootPath);

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
        public IActionResult Edit(Food food,IFormFile photoUrl)
        {
            
            var result = _foodService.Update(food,photoUrl,_env.WebRootPath);

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
