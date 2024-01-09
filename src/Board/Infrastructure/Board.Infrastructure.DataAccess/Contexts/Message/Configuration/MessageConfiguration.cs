using Board.Domain.Message;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Board.Infrastructure.DataAccess.Contexts.Message.Configuration;

/// <summary>
/// Конфигурация сущности личного сообщения.
/// </summary>
public class MessageConfiguration : IEntityTypeConfiguration<Messages>
{
    public void Configure(EntityTypeBuilder<Messages> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Text).HasMaxLength(500);
        builder.Property(p => p.SentAt).HasConversion(to => to, from => DateTime.SpecifyKind(from, DateTimeKind.Utc));
        builder.Property(p => p.IsRead).HasDefaultValue(false);
    }
}