using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace FinalProject.Web.ViewModels
{
    public class HomeViewModel
    {
        public List<About> Abouts { get; set; }
        public List<FoodDto> Foods { get; set; }
        public List<Testimonial> Testimonials { get; set; }
        public List<FoodCategory> FoodCategories { get; set; }
    }
}
