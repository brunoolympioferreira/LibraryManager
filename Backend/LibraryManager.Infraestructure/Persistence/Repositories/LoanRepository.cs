using LibraryManager.Core.Entities;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Infraestructure.Persistence.Repositories;
public class LoanRepository : ILoanRepository
{
    private readonly LibraryManagerDbContext _context;
    public LoanRepository(LibraryManagerDbContext context)
    {
        _context = context;
    }
    public async Task AddAsync(Loan loan)
    {
        await _context.Loans.AddAsync(loan);
        await _context.SaveChangesAsync();
    }
}
