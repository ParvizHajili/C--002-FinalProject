using Core.DataAccess.Concrete;
using DataAccess.Asbtract;
using DataAccess.Context;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete
{
    public class ContactDal: BaseRepository<Contact, ApplicationDbContext>,IContactDal { }
}
