using Board.Domain.Advertisement;
using Board.Domain.ImageKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.ImageKit.Configuration;

/// <summary>
/// Конфигурация сущности объявления.
/// </summary>
public class ImageKitConfiguration : IEntityTypeConfiguration<ImageKits>
{
    public void Configure(EntityTypeBuilder<ImageKits> builder)
    {
        builder.HasKey(k => k.AdvertisementId);
    }
}