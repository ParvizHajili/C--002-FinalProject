using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFoodCategoryService
    {
        IResult Add(FoodCategory entity);
        IResult Update(FoodCategory entity);
        IResult Delete(int id);
        IDataResult<List<FoodCategory>> GetAll();
        IDataResult<FoodCategory> GetById(int id);
    }
}
