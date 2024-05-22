using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class BlogTag : BaseEntity, IEntity
    {
        public int BlogId { get; set; }
        public int TagId { get; set; }
        public Blog Blog { get; set; }
        public Tag Tag { get; set; }
    }
}
