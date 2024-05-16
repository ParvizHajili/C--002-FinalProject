using Business.Abstract;
using FinalProject.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FinalProject.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAboutService _aboutService;

        private readonly IFoodCategoryService _foodCategoryService;
        private readonly IFoodService _foodService;
        public HomeController(IAboutService aboutService, 
            IFoodCategoryService foodCategoryService,
            IFoodService foodService)
        {
            _aboutService = aboutService;
            _foodCategoryService = foodCategoryService;
            _foodService = foodService;
        }


        public IActionResult Index()
        {
            var aboutData = _aboutService.GetAll().Data;
            var foodCategoryData = _foodCategoryService.GetAll().Data;
            var foodData = _foodService.GetFoodWithFoodCategoryId().Data;
            HomeViewModel viewModel = new()
            {
                Abouts = aboutData,
                FoodCategories = foodCategoryData,
                Foods= foodData,
            };
            return View(viewModel);
        }
    }
}
