using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Asbtract
{
    public interface IBlogDal : IBaseRepository<Blog>
    {
        void AddWithTag(Blog blog, int[] tagIds);
    }
}
