using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class About : BaseEntity, IEntity
    {
        public string Description { get; set; }
    }
}
