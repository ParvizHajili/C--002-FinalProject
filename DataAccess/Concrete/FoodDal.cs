using Core.DataAccess.Concrete;
using DataAccess.Asbtract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class FoodDal : BaseRepository<Food, ApplicationDbContext>, IFoodDal
    {
        ApplicationDbContext _context = new();
        public List<FoodDto> GetFoodWithFoodCategories()
        {
            var result = from food in _context.Foods
                         where food.Deleted == 0
                         join foodC in _context.FoodCategories
                         on food.FoodCategoryId equals foodC.Id
                         where foodC.Deleted == 0
                         select new FoodDto
                         {
                             Id = food.Id,
                             Name = food.Name,
                             Description = food.Description,
                             IsHomePage = food.IsHomePage,
                             PhotoUrl = food.PhotoUrl,
                             FoodCategoryId = food.FoodCategoryId,
                             Price = food.Price,
                             FoodCategoryName = foodC.Name,
                         };

            return result.ToList();
        }
    }
}
