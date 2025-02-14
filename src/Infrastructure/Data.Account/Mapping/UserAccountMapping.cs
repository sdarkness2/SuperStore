using Account.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Account.Mapping;

public class UserAccountMapping : IEntityTypeConfiguration<UserAccount>
{
    public void Configure(EntityTypeBuilder<UserAccount> builder)
    {
        builder.ToTable("account");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Name)
            .HasColumnType("varchar(50)")
            .IsRequired();

        builder.Property(x => x.Email)
            .HasColumnType("varchar(150)")
            .IsRequired();

        builder.Property(x => x.Password)
            .HasColumnType("varchar(20)")
            .IsRequired();

        builder.Property(x => x.BirthDate)
            .HasColumnType("date")
            .IsRequired();

        builder.Property(x => x.IsDeleted)
            .HasColumnType("boolean")
            .IsRequired();
    }
}