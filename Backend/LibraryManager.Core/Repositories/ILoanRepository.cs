using LibraryManager.Core.Entities;

namespace LibraryManager.Core.Repositories;
public interface ILoanRepository
{
    Task AddAsync(Loan loan);
}
