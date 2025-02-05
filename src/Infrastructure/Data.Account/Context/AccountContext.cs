using Account.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Account.Context;

public sealed class AccountContext : DbContext
{
    public DbSet<UserAccount> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite();
}
