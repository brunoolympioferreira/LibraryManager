using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infraestructure.Persistence.Configurations;
public class LoanConfigurations : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        builder.HasKey(l => l.Id);

        builder
            .HasOne(u => u.User)
            .WithOne(l => l.Loan)
            .HasForeignKey<User>(u => u.Id)
            .HasConstraintName("userId");

        builder
            .HasOne(b => b.Book)
            .WithOne(l => l.Loan)
            .HasForeignKey<Book>(b => b.Id)
            .HasConstraintName("bookId");

        builder.Ignore(b => b.Events);
    }
}
