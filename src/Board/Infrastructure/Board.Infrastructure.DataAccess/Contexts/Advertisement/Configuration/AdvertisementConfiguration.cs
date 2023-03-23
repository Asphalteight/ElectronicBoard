using Board.Domain.Advertisement;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Advertisement.Configuration;

public class AdvertisementConfiguration : IEntityTypeConfiguration<Advertisements>
{
    public void Configure(EntityTypeBuilder<Advertisements> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Title).HasMaxLength(25);
        builder.Property(p => p.Description).HasMaxLength(500);
        builder.Property(p => p.Price);
        builder.Property(p => p.CreatedAt).HasConversion(to => to, from => DateTime.SpecifyKind(from, DateTimeKind.Utc));
        builder.Property(p => p.IsActive);

        builder.HasMany(f => f.CommentsList)
            .WithOne(o => o.Advertisement)
            .HasForeignKey(f => f.AdvertisementId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}