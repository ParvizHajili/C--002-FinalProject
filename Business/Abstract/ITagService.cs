using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface ITagService
    {
        IResult Add(Tag tag);
        IDataResult<List<Tag>> GetAll();
    }
}
