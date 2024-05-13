using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        FoodDal FoodDal = new();

        public IResult Add(Food entity)
        {
            FoodDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Update(Food entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            FoodDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            FoodDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<Food> GetById(int id)
        {
            return new SuccessDataResult<Food>(FoodDal.GetById(id));
        }

        public IDataResult<List<Food>> GetFoodWithFoodCategoryId()
        {
            return new SuccessDataResult<List<Food>>(FoodDal.GetFoodWithFoodCategories());
        }
    }
}
