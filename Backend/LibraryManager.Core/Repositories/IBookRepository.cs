using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;
public interface IBookRepository
{
    Task AddAsync(Book book);
    Task<List<Book>> GetAllAsync();
    Task<Book> GetByIdAsync(Guid id);
    Task DeleteAsync(Guid id);
}
