using Core.Results.Abstract;
using Entities.Concrete.Dtos;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IBlogservice
    {
        IResult Add(Blog blog);
        IResult Add(Blog blog, int[] tagIds);
        IResult Add(BlogCreateDto dto);
        IDataResult<List<Blog>> GetAll();
    }
}
