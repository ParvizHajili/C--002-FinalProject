using Business.Abstract;
using Business.BaseMessages;
using Business.Validations;
using Core.Results.Abstract;
using Core.Results.Concrete;
using Core.Validation;
using DataAccess.Asbtract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;
using FluentValidation;
using Core.Extenstions;

namespace Business.Concrete
{
    public class AboutManager : IAboutService
    {
        private readonly IAboutDal _aboutdal;
        private readonly IValidator<About> _validator;
        public AboutManager(IAboutDal aboutDal, IValidator<About> validator)
        {
            _aboutdal = aboutDal;
            _validator = validator;
        }
        public IResult Add(AboutCreateDto dto)
        {
            var model = AboutCreateDto.ToAbout(dto);

            var validator = ValidationTool.Validate(new AboutValidation(), model, out List<ValidationErrorModel> errors);

            if (!validator)
            {
                return new ErrorResult(errors.ValidationErrorMessagesWithNewLine());
            }

            _aboutdal.Add(model);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_aboutdal.GetAll());
        }

        public IDataResult<About> GetById(int id)
        {
            return new SuccessDataResult<About>(_aboutdal.GetById(id));
        }

        public IResult Update(About entity)
        {
            entity.LastUpdateDate = DateTime.Now;
            _aboutdal.Update(entity);

            return new SuccessResult(UIMessages.UPDATE_MESSAGE);
        }
    }
}
