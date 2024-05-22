using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class Food : BaseEntity, IEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FoodCategoryId { get; set; }
        public bool IsHomePage { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public virtual FoodCategory FoodCategory { get; set; }
    }
}
