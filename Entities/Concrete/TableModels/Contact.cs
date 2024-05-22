using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Contact : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
    }
}
