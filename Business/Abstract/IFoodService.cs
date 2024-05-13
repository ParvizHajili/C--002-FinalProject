using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IResult Add(Food entity);
        IResult Update(Food entity);
        IResult Delete(int id);
        IDataResult<List<Food>> GetFoodWithFoodCategoryId();
        IDataResult<Food> GetById(int id);
    }
}
