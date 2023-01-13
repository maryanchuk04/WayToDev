using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WayToDev.Core.Entities;

namespace WayToDev.Db.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder
            .HasOne(a => a.Company)
            .WithOne(b => b.Account)
            .HasForeignKey<Company>(b => b.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(a => a.User)
            .WithOne(b => b.Account)
            .HasForeignKey<User>(b => b.AccountId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}