using Account.Entities;
using Data.Account.Mapping;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace Data.Account.Context;

[ExcludeFromCodeCoverage]
public sealed class AccountContext : DbContext
{
    public DbSet<UserAccount> Accounts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlite("Data Source=C:\\Workspace\\SuperStore\\SuperStore.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new UserAccountMapping());

        modelBuilder.Entity<UserAccount>()
            .Property(x => x.CreatedAt)
            .HasColumnName("Created_At")
            .HasColumnType("DATETIME");

        modelBuilder.Entity<UserAccount>()
            .Property(x => x.UpdatedAt)
            .HasColumnName("Updated_At")
            .HasColumnType("DATETIME");

        modelBuilder.Entity<UserAccount>()
            .Property(x => x.DeletedAt)
            .HasColumnName("Deleted_At")
            .HasColumnType("DATETIME");
    }
}
