using Board.Domain.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Board.Infrastructure.DataAccess.Contexts.Comment.Configuration;

/// <summary>
/// Конфигурация сущности комментария.
/// </summary>
public class CommentConfiguration : IEntityTypeConfiguration<Comments>
{
    public void Configure(EntityTypeBuilder<Comments> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Text).HasMaxLength(500);
        builder.Property(p => p.CreatedAt).HasConversion(to => to, from => DateTime.SpecifyKind(from, DateTimeKind.Utc));
    }
}