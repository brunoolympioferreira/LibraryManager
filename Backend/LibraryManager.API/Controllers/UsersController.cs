using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserInputModel model)
    {
        var result = await _userService.Register(model);

        return Ok(result);
    }
}
