using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Asbtract;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class BlogManager : IBlogservice
    {
        private readonly IBlogDal _blogDal;
        public BlogManager(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }
        public IResult Add(Blog blog)
        {
            _blogDal.Add(blog);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IResult Add(Blog blog, int[] tagIds)
        {
            _blogDal.Add(blog);

            _blogDal.AddWithTag(blog, tagIds);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IDataResult<List<Blog>> GetAll()
        {
            return new SuccessDataResult<List<Blog>>(_blogDal.GetAll(x => x.Deleted == 0));
        }
    }
}
