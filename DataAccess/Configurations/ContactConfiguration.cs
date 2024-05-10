using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class ContactConfiguration : IEntityTypeConfiguration<Contact>
    {
        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            builder.ToTable("Contacts");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Email)
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.Title)
               .HasMaxLength(300)
               .IsRequired();

            builder.Property(x => x.Message)
               .HasMaxLength(2000)
               .IsRequired();

            builder.HasIndex(x => x.Email);

            builder.HasIndex(x => new { x.Email, x.Deleted })
                .IsUnique()
                .HasDatabaseName("idx_Email_Deleted");
        }
    }
}
