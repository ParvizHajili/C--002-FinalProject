using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class BlogTagConfiguration : IEntityTypeConfiguration<BlogTag>
    {
        public void Configure(EntityTypeBuilder<BlogTag> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.HasOne(x => x.Blog)
                .WithMany(x => x.BlogTags)
                .HasForeignKey(x => x.BlogId);

            builder.HasOne(x => x.Tag)
                .WithMany(x => x.BlogTags)
                .HasForeignKey(x => x.TagId);
        }
    }
}
