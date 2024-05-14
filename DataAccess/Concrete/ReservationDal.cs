using Core.DataAccess.Concrete;
using DataAccess.Asbtract;
using DataAccess.Context;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class ReservationDal : BaseRepository<Reservation, ApplicationDbContext>, IReservationDal { }
}
