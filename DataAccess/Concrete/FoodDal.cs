using Core.DataAccess.Concrete;
using DataAccess.Asbtract;
using DataAccess.Context;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class FoodDal : BaseRepository<Food, ApplicationDbContext>, IFoodDal
    {
        private readonly ApplicationDbContext _context;

        public FoodDal(ApplicationDbContext context)
        {
            _context = context;
        }

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
            //return result.ToList();
            //var data = _context.Foods.Find(10000);
            //first => göndərdiyimiz parametrə uyğun bir neçə data varsa ilkini gətirir
            //data yoxdursa error atir
            //firstordefault => göndərdiyimiz parametrə uyğun bir neçə data varsa ilkini gətirir
            //data yoxdursa null qaytarir
            //single =>göndərdiyimiz parametrə uyğun bir neçə data varsa xeta atir
            //data yoxdursa xeta atir
            //singleordefault => göndərdiyimiz parametrə uyğun bir neçə data varsa xeta atir
            //data yoxdursa null deyer qaytarir
            //first ve firstordefault

            //var data = _context.Foods.Where(x => x.IsHomePage == false)
            //    .OrderBy(x => x.Name)
            //    .LastOrDefault();



            //return new List<FoodDto>();
        }
    }
}
