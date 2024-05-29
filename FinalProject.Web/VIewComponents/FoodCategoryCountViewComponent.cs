using Business.Abstract;
using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.VIewComponents
{
    public class FoodCategoryCountViewComponent : ViewComponent
    {
        private readonly IFoodCategoryService _foodCategoryService;
        public FoodCategoryCountViewComponent(IFoodCategoryService foodCategoryService)
        {
            _foodCategoryService = foodCategoryService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var count = _foodCategoryService.GetAll().Data.Count;

            return View(new FoodCategoryCountViewModel()
            {
                Count = count
            });
        }
    }
}
