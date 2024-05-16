using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Abstract
{
    public interface IFoodService
    {
        IResult Add(Food entity,IFormFile photoUrl,string webRootPath);
        IResult Update(Food entity, IFormFile photoUrl, string webRootPath);
        IResult Delete(int id);
        IDataResult<List<FoodDto>> GetFoodWithFoodCategoryId();
        IDataResult<Food> GetById(int id);
    }
}
