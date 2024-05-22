using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Tag : BaseEntity,IEntity
    {
        public string Name { get; set; }
        public List<Blog> Blogs { get; set; }
        public List<BlogTag> BlogTags { get; set; }
    }
}
