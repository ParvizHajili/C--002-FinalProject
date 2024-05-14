using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryUpdateDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconName { get; set; }

        public static FoodCategory ToFoodCategory(FoodCategoryUpdateDto dto)
        {
            FoodCategory category = new()
            {
                Id = dto.Id,
                Name = dto.Name,
                IconName = dto.IconName,
            };
            return category;
        }
    }
}
