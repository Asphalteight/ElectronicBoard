using Board.Domain.Account;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Board.Infrastructure.DataAccess.Contexts.Account.Configuration;

public class AccountConfiguration : IEntityTypeConfiguration<Accounts>
{
    public void Configure(EntityTypeBuilder<Accounts> builder)
    {
        builder.HasKey(k => k.Id);
        builder.Property(p => p.Name);
        builder.Property(p => p.Email);
        builder.Property(p => p.Phone);
        builder.Property(p => p.Password);

        builder.HasMany(f => f.AdvertisementsList)
            .WithOne(o => o.Account)
            .HasForeignKey(f => f.AccountId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}