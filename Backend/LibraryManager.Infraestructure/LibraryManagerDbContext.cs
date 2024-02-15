using LibraryManager.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace LibraryManager.Infraestructure;
public class LibraryManagerDbContext : DbContext
{
    public LibraryManagerDbContext(DbContextOptions<LibraryManagerDbContext> options) : base(options) { }
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
