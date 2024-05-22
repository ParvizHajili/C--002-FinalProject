using Business.Abstract;
using Business.BaseMessages;
using Core.Results.Abstract;
using Core.Results.Concrete;
using DataAccess.Asbtract;
using Entities.Concrete.TableModels;

namespace Business.Concrete
{
    public class TagManager : ITagService
    {
        private readonly ITagDal _tagDal;
        public TagManager(ITagDal tagDal)
        {
            _tagDal = tagDal;
        }
        public IResult Add(Tag tag)
        {
            _tagDal.Add(tag);

            return new SuccessResult(UIMessages.ADDED_MESSAGE);
        }

        public IDataResult<List<Tag>> GetAll()
        {
            return new SuccessDataResult<List<Tag>>(_tagDal.GetAll(x => x.Deleted == 0));
        }
    }
}
