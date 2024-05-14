using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class FoodCategoryCreateDto
    {
        public string CategoryName { get; set; }
        public string IconName { get; set; }

        public static FoodCategory ToFoodCategory(FoodCategoryCreateDto dto)
        {
            FoodCategory foodCategory = new()
            {
                Name = dto.CategoryName,
                IconName = dto.IconName,
            };

            return foodCategory;
        }
    }
}
