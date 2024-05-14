using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int FoodCategoryId { get; set; }
        public bool IsHomePage { get; set; }
        public decimal Price { get; set; }
        public string PhotoUrl { get; set; }
        public string FoodCategoryName { get; set; }
    }
}
