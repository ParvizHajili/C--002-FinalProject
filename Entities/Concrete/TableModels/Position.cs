using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Position : BaseEntity, IEntity
    {
        public Position()
        {
            Teams = new HashSet<Team>();
        }
        public string Name { get; set; }
        public ICollection<Team> Teams { get; set; }
    }
}
