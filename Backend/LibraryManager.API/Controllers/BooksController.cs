using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;
using LibraryManager.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManager.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _service;
    public BooksController(IBookService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterBookInputModel model)
    {
        var result = await _service.Register(model);

        return Ok(result);
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var books = await _service.GetAll();

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var book = await _service.GetById(id);

        if (book.Success == false) return NotFound(book);

        return Ok(book);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.Delete(id);

        return Ok(result);
    }

    [HttpPost("loan")]
    public async Task<IActionResult> CreateLoan([FromBody] LoanInputModel model)
    {
        var result = await _service.AddLoan(model);

        return Ok(result);
    }

    [HttpPost("devolution")]
    public async Task<IActionResult> CreateDevolutioin([FromBody] DevolutionLoanInputModel model)
    {
        var result = await _service.AddDevolutionLoan(model);

        return Ok(result);
    }
}
