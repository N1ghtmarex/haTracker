using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class TaskEntityConfiguration : IEntityTypeConfiguration<Entities.Task>
{
    public void Configure(EntityTypeBuilder<Entities.Task> builder)
    {
        builder.ToTable("task");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.AuthorId)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.AuthorId).IsUnique(false);
        builder.HasOne(x => x.Author)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.TaskTypeId)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.TaskTypeId).IsUnique(false);
        builder.HasOne(x => x.TaskType)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.TaskTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.Title).IsRequired().HasMaxLength(100);

        builder.Property(x => x.EmojiId)
            .IsRequired(false)
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.EmojiId).IsUnique(false);
        builder.HasOne(x => x.Emoji)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.EmojiId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.ColorId)
            .IsRequired(true)
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.ColorId).IsUnique(false);
        builder.HasOne(x => x.Color)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.ColorId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.TrackingType).IsRequired();

        builder.Property(x => x.UnitId)
            .IsRequired(false)
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.UnitId).IsUnique(false);
        builder.HasOne(x => x.Unit)
            .WithMany(x => x.Tasks)
            .HasForeignKey(x => x.UnitId)
            .OnDelete(DeleteBehavior.SetNull);

        builder.Property(x => x.TargetValue).IsRequired();

        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.Property(x => x.IsArchive).IsRequired();
    }
}
