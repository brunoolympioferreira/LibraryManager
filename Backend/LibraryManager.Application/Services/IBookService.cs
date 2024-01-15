using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;

namespace LibraryManager.Application.Services;
public interface IBookService
{
    Task<BaseResult<Guid>> Register(RegisterBookInputModel model);
}
