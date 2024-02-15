using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager.Infraestructure.Persistence.Repositories;
public class UserRepository : IUserRepository
{
    private readonly LibraryManagerDbContext _context;
    public UserRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(User user)
    {
        await _context.Users.AddAsync(user);

        await _context.SaveChangesAsync();
    }

    public async Task<User> GetByIdAsync(Guid id)
    {
        User? user = await _context.Users.AsNoTracking().SingleOrDefaultAsync(u => u.Id == id);

        return user;
    }
}
