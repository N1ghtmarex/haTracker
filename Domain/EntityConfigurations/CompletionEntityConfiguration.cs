using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.EntityConfigurations;

public class CompletionEntityConfiguration : IEntityTypeConfiguration<Completion>
{
    public void Configure(EntityTypeBuilder<Completion> builder)
    {
        builder.ToTable("completion");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.Id).IsUnique();

        builder.Property(x => x.UserId)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.UserId).IsUnique(false);
        builder.HasOne(x => x.User)
            .WithMany(x => x.Completions)
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.TaskId)
            .IsRequired()
            .HasConversion(
                x => x.ToString(),
                x => Ulid.Parse(x)
            );
        builder.HasIndex(x => x.TaskId).IsUnique(false);
        builder.HasOne(x => x.Task)
            .WithMany(x => x.Completions)
            .HasForeignKey(x => x.TaskId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(x => x.IsCompleted).IsRequired();
        builder.Property(x => x.CurrentValue).IsRequired(false);

        builder.Property(x => x.CreatedAt).IsRequired();
        builder.Property(x => x.UpdatedAt).IsRequired();
        builder.Property(x => x.IsArchive).IsRequired();
    }
}
