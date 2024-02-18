using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;

namespace LibraryManager.Application.Services;
public interface IBookService
{
    Task<BaseResult<Guid>> Register(RegisterBookInputModel model);
    Task<BaseResult<List<BookViewModel>>> GetAll();
    Task<BaseResult<BookViewModel>> GetById(Guid id);
    Task<BaseResult> Delete(Guid id);
    Task<BaseResult<Guid>> AddLoan(LoanInputModel model);
    Task<BaseResult<DevolutionResultViewModel>> AddDevolutionLoan(DevolutionLoanInputModel model);
}
