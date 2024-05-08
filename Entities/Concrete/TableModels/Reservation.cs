using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Reservation : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte PeopleCount { get; set; }
        public string Message { get; set; }
        public bool IsContacted { get; set; }
    }
}
