using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;

namespace LibraryManager.Application.Services;
public interface IUserService
{
    Task<BaseResult<Guid>> Register(RegisterUserInputModel model);
}
