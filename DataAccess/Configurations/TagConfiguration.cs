using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(50);

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();

            builder.HasMany(x => x.BlogTags)
                 .WithOne(x => x.Tag)
                 .HasForeignKey(x => x.TagId);
        }
    }
}
