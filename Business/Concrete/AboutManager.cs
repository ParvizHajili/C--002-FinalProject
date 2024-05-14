using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Concrete;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        AboutDal _aboutService = new();
        public IResult Add(About entity)
        {
            _aboutService.Add(entity);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutService.GetAll());
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutService.GetById(id));
        }

        public IResult Update(About entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _aboutService.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
