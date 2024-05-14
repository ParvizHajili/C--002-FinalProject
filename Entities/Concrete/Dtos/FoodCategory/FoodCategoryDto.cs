using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryDto
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public string IconName { get; set; }
    }
}
