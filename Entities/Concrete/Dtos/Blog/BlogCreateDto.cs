using Entities.Concrete.TableModels;

namespace Entities.Concrete.Dtos
{
    public class BlogCreateDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int[] tagIds { get; set; }

        public static Blog ToBlog(BlogCreateDto dto)
        {
            Blog blog = new()
            {
                Title = dto.Title,
                Description = dto.Description,
            };

            return blog;
        }
    }
}
