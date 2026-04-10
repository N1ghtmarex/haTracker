using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.ExternalUserId).IsRequired();
        builder.HasIndex(x => x.ExternalUserId).IsUnique();

        builder.Property(x => x.Username).IsRequired().HasMaxLength(16);
        builder.HasIndex(x => x.Username).IsUnique();

        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.Property(x => x.IsArchive).IsRequired();
    }
}
