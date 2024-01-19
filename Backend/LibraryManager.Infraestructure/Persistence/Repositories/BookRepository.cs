using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

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

    public async Task<List<Book>> GetAllAsync()
    {
        List<Book> books = await _context.Books.AsNoTracking().ToListAsync();

        return books;
    }
}
