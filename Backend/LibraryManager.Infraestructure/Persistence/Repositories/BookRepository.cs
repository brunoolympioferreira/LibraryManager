using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Infraestructure.Persistence.Repositories;
public class BookRepository : IBookRepository
{
    private readonly LibraryManagerDbContext _context;
    public BookRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Book book)
    {
        await _context.Books.AddAsync(book);

        await _context.SaveChangesAsync();
    }
}
