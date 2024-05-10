using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class FoodConfiguration : IEntityTypeConfiguration<Food>
    {
        public void Configure(EntityTypeBuilder<Food> builder)
        {
            builder.ToTable("Foods");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.PhotoUrl)
                .HasMaxLength(200)
                .IsRequired();

            builder.Property(x => x.IsHomePage)
                .HasDefaultValue(false)
               .IsRequired();

            builder.Property(x => x.Price)
                .HasPrecision(7, 2);

            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name)
                .IsUnique();

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();

            builder.HasOne(x => x.FoodCategory)
                .WithMany(x => x.Foods)
                .HasForeignKey(x => x.FoodCategoryId);
        }
    }
}
