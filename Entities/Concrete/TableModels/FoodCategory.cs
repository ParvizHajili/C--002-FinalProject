using Core.Entities.Abstract;

namespace Entities.Concrete.TableModels
{
    public class FoodCategory : BaseEntity
    {
        public FoodCategory()
        {
            Foods = new HashSet<Food>();
        }

        public string Name { get; set; }
        public string IconName { get; set; }
        public ICollection<Food> Foods { get; set; }
    }
}
