using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IResult Add(Food entity);
        IResult Update(Food entity);
        IResult Delete(int id);
        IDataResult<List<FoodDto>> GetFoodWithFoodCategoryId();
        IDataResult<Food> GetById(int id);
    }
}
