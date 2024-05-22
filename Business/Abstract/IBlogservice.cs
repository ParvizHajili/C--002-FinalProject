using Core.Results.Abstract;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IBlogservice
    {
        IResult Add(Blog blog);
        IResult Add(Blog blog, int[] tagIds);
        IDataResult<List<Blog>> GetAll();
    }
}
