using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Reservation : BaseEntity, IEntity
    {
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public DateTime ReservationDate { get; set; }
        public byte PeopleCount { get; set; }
        public string Message { get; set; }
        public bool IsContacted { get; set; }
    }
}
