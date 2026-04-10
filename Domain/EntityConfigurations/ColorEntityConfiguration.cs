using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {
        builder.ToTable("color");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.Value).IsRequired().HasMaxLength(8);
        builder.HasIndex(x => x.Value).IsUnique();

        builder.Property(x => x.IsArchive).IsRequired();
    }
}
