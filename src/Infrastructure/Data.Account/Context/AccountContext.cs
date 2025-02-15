using Account.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Data.Account.Context;

[ExcludeFromCodeCoverage]
public sealed class AccountContext : DbContext
{
    public DbSet<UserAccount> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite("C:\\Workspace\\SuperStore\\SuperStore.db");
}
