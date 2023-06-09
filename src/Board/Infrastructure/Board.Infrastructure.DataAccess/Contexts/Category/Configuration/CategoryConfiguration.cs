﻿using Board.Domain.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Category.Configuration;

/// <summary>
/// Конфигурация сущности категории.
/// </summary>
public class CategoryConfiguration : IEntityTypeConfiguration<Categories>
{
    public void Configure(EntityTypeBuilder<Categories> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.ParentCategoryId).HasDefaultValue(0);
        builder.Property(p => p.Name).HasMaxLength(50);

        builder.HasMany(f => f.AdvertisementsList)
            .WithOne(o => o.Category)
            .HasForeignKey(f => f.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}