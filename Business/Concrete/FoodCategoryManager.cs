using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class FoodCategoryManager : IFoodCategoryService
    {
        FoodCategoryDal foodCategoryDal = new();
        public IResult Add(FoodCategoryCreateDto dto)
        {
            var model = FoodCategoryCreateDto.ToFoodCategory(dto);

            foodCategoryDal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }


        public IResult Update(FoodCategoryUpdateDto dto)
        {
            var model = FoodCategoryUpdateDto.ToFoodCategory(dto);
            model.LastUpdateDate = DateTime.Now;

            foodCategoryDal.Update(model);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;
            data.Deleted = id;

            foodCategoryDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<List<FoodCategory>> GetAll()
        {
            return new SuccessDataResult<List<FoodCategory>>(foodCategoryDal.GetAll(x => x.Deleted == 0));
        }

        public IDataResult<FoodCategory> GetById(int id)
        {
            return new SuccessDataResult<FoodCategory>(foodCategoryDal.GetById(id));
        }
    }
}
