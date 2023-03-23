using Board.Domain.Comment;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Comment.Configuration;

public class CommentConfiguration : IEntityTypeConfiguration<Comments>
{
    public void Configure(EntityTypeBuilder<Comments> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Text).HasMaxLength(10000);
        builder.Property(p => p.CreatedAt).HasConversion(to => to, from => DateTime.SpecifyKind(from, DateTimeKind.Utc));
    }
}