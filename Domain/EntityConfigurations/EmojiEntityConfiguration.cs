using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class EmojiEntityConfiguration : IEntityTypeConfiguration<Emoji>
{
    public void Configure(EntityTypeBuilder<Emoji> builder)
    {
        builder.ToTable("emoji");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.Value).IsRequired().HasMaxLength(1);
        builder.HasIndex(x => x.Value).IsUnique();

        builder.Property(x => x.IsArchive).IsRequired();
    }
}
