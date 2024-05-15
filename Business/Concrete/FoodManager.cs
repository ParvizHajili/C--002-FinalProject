using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Asbtract;
using DataAccess.Concrete;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public IResult Add(Food entity)
        {
            _foodDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Update(Food entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _foodDal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }

        public IResult Delete(int id)
        {
            var data = GetById(id).Data;

            data.Deleted = id;

            _foodDal.Update(data);

            return new SuccessResult(UIMessages.Deleted_MESSAGE);
        }

        public IDataResult<Food> GetById(int id)
        {
            return new SuccessDataResult<Food>(_foodDal.GetById(id));
        }

        public IDataResult<List<FoodDto>> GetFoodWithFoodCategoryId()
        {
            return new SuccessDataResult<List<FoodDto>>(_foodDal.GetFoodWithFoodCategories());
        }
    }
}
