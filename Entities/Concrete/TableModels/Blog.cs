using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Blog : BaseEntity,IEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Tag> Tags { get; set; }
        public List<BlogTag> BlogTags { get; set; }
    }
}
