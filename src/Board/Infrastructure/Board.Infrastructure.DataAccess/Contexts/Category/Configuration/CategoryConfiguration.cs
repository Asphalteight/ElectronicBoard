using Board.Domain.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Category.Configuration;

public class CategoryConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name).HasMaxLength(50);

        builder.HasMany(f => f.SubcategoriesList)
            .WithOne(o => o.Category)
            .HasForeignKey(f => f.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}