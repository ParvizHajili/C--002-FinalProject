using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Testimonial : BaseEntity, IEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Feedback { get; set; }
        public string PhotoUrl { get; set; }
    }
}
