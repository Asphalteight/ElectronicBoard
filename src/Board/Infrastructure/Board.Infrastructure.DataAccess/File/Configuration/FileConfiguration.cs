using Board.Domain.File;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.File.Configuration
{
    /// <summary>
    /// Конфигурация сущности Файла.
    /// </summary>
    public class FileConfiguration : IEntityTypeConfiguration<Files>
    {
        /// <inheritdoc/>
        public void Configure(EntityTypeBuilder<Files> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Name).HasMaxLength(256).IsRequired();
            builder.Property(a => a.ContentType).HasMaxLength(256).IsRequired();
            builder.Property(a => a.CreatedAt).HasConversion(s => s, s => DateTime.SpecifyKind(s, DateTimeKind.Utc));
        }
    }
}
