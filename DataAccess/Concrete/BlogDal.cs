using Core.DataAccess.Concrete;
using DataAccess.Asbtract;
using DataAccess.Context;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class BlogDal : BaseRepository<Blog, ApplicationDbContext>, IBlogDal
    {
        private readonly ApplicationDbContext _context;
        public BlogDal(ApplicationDbContext context)
        {
            _context = context;
        }
        public void AddWithTag(Blog blog, int[] tagIds)
        {
            foreach (int tagid in tagIds)
            {
                var tag = _context.Tags.Find(tagid);

                var blogTag = new BlogTag
                {
                    BlogId = blog.Id,
                    Tag = tag,
                };

                _context.BlogTags.Add(blogTag);
            }

            _context.SaveChanges();
        }
    }
}
