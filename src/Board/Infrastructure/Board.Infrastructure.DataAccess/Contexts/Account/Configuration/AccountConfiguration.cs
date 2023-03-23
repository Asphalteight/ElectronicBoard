using Board.Domain.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Account.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Accounts>
{
    public void Configure(EntityTypeBuilder<Accounts> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name).HasMaxLength(25);
        builder.Property(p => p.Email).HasMaxLength(320);
        builder.Property(p => p.Phone).HasMaxLength(15);
        builder.Property(p => p.Password).HasMaxLength(127);

        builder.HasMany(f => f.AdvertisementsList)
            .WithOne(o => o.Account)
            .HasForeignKey(f => f.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}