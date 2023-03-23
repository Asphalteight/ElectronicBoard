using Board.Domain.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Subcategory.Configuration;

public class SubcategoryConfiguration : IEntityTypeConfiguration<Subcategories>
{
    public void Configure(EntityTypeBuilder<Subcategories> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name);

        builder.HasMany(f => f.AdvertisementsList)
            .WithOne(o => o.Subcategory)
            .HasForeignKey(f => f.SubcategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}