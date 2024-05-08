using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string FacebookLink { get; set; }
        public string TwitterLink { get; set; }
        public string InstagramLink { get; set; }
        public int PositionId { get; set; }
        public virtual Position Position { get; set; }
    }
}
