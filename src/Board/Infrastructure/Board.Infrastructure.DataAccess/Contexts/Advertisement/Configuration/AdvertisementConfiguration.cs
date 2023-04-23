using Board.Domain.Advertisement;
using Board.Domain.ImageKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Advertisement.Configuration;

/// <summary>
/// Конфигурация сущности объявления.
/// </summary>
public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisements>
{
    public void Configure(EntityTypeBuilder<Advertisements> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Title).HasMaxLength(25);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Address).HasMaxLength(250);
        builder.Property(p => p.CreatedAt).HasConversion(to => to, from => DateTime.SpecifyKind(from, DateTimeKind.Utc));

        builder.HasOne<ImageKits>(p => p.ImageKit).WithOne(s => s.Advertisement);
        
        builder.HasMany(f => f.CommentsList)
            .WithOne(o => o.Advertisement)
            .HasForeignKey(f => f.AdvertisementId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}