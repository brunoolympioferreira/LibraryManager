using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Application.Services;
public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    public UserService(IUserRepository repository)
    {
        _repository = repository;
    }
    public async Task<BaseResult<Guid>> Register(RegisterUserInputModel model)
    {
        var user = model.ToEntity();

        await _repository.AddAsync(user);

        return new BaseResult<Guid>(user.Id);
    }
}
