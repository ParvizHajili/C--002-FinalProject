using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IFoodCategoryService
    {
        IResult Add(FoodCategoryCreateDto dto);
        IResult Update(FoodCategoryUpdateDto dto);
        IResult Delete(int id);
        IDataResult<List<FoodCategory>> GetAll();
        IDataResult<FoodCategory> GetById(int id);
    }
}
