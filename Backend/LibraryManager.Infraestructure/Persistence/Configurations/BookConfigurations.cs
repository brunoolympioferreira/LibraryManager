using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManager.Infraestructure.Persistence.Configurations;
public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.HasKey(b => b.Id);

        builder.Property(b => b.Title).HasMaxLength(100).IsRequired();
        builder.Property(b => b.Author).HasMaxLength(100).IsRequired();
        builder.Property(b => b.ISBN).HasMaxLength(13).IsRequired();
        builder.Property(b => b.PublishedYear).HasMaxLength(4).IsRequired();

        builder.Ignore(b => b.Events);

    }
}
