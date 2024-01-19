using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;
using LibraryManager.Core.Entities;

namespace LibraryManager.Application.Services;
public interface IBookService
{
    Task<BaseResult<Guid>> Register(RegisterBookInputModel model);
    Task<BaseResult<List<BookViewModel>>> GetAll();
}
