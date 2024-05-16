using Business.Abstract;
using Business.BaseMessages;
using Core.Extenstion;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Asbtract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using Microsoft.AspNetCore.Http;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        private readonly IFoodDal _foodDal;

        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }

        public IResult Add(Food entity,IFormFile photoUrl,string webRootPath)
        {
            entity.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);

            _foodDal.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Update(Food entity, IFormFile photoUrl, string webRootPath)
        {
            var existData = GetById(entity.Id).Data;
            if (photoUrl == null)
            {
                entity.PhotoUrl = existData.PhotoUrl;
            }
            else
            {
                entity.PhotoUrl = PictureHelper.UploadImage(photoUrl, webRootPath);
            }
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
