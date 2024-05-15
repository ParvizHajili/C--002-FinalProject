using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IResult Add(AboutCreateDto dto);
        IResult Update(About entity);
        IDataResult<List<About>> GetAll();
        IDataResult<About> GetById(int id);
    }
}
