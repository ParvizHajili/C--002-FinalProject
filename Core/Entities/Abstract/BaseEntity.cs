namespace Core.Entities.Abstract
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public int Deleted { get; set; } = 0;
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? LastUpdateDate { get; set; }
    }
}
