﻿using LibraryManager.Application.DTO.InputModels;
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
}