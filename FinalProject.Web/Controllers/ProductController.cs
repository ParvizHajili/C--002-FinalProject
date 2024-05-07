using FinalProject.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Web.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
           List<Car> cars = new()
           {
               new Car { Id = 1,Name="Hyundai"},
               new Car { Id = 2,Name="Bmw"},
               new Car { Id = 3,Name="Mercedes"}
           };

            return View(cars);
        }

        public IActionResult Detail()
        {
            return View();
        }
    }
}
