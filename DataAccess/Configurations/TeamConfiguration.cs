using Core.DefaultValues;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configurations
{
    public class TeamConfiguration : IEntityTypeConfiguration<Team>
    {
        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.ToTable("Teams");

            builder.Property(x => x.Id)
                .UseIdentityColumn(seed: DefaultConstantValue.DEFAULT_PRIMARY_INCREMENT_VALUE, increment: 1);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.SurName)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.FacebookLink)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.InstagramLink)
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.TwitterLink)
                .HasMaxLength(150)
                .IsRequired();

            builder.HasIndex(x => new { x.Name, x.Deleted })
                .IsUnique();

            builder.HasOne(x => x.Position)
                .WithMany(x => x.Teams)
                .HasForeignKey(x => x.PositionId);
        }
    }
}
