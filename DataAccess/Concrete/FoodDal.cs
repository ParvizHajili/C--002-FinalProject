using Core.DataAccess.Concrete;
using DataAccess.Asbtract;
using DataAccess.Context;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class FoodDal : BaseRepository<Food, ApplicationDbContext>, IFoodDal
    {
        ApplicationDbContext context = new();
        public List<Food> GetFoodWithFoodCategories()
        {
            var data = context.Foods
                .Where(x => x.Deleted == 0)
                .Include(x => x.FoodCategory).ToList();

            return data;
        }
    }
}
