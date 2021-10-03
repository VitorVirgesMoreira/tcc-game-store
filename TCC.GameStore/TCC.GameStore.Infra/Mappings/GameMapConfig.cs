using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TCC.GameStore.Domain.Entities;

namespace TCC.GameStore.Infra.Mappings
{
    public class GameMapConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable("Games");

            builder.Property(x => x.Id)
                .UseIdentityColumn();

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Developer)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.DateLaunch)
                .IsRequired();

            builder.Property(x => x.Price)
                .IsRequired();
        }
    }
}
