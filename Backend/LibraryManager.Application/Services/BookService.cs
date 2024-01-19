using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Application.Services;
public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<BaseResult<List<BookViewModel>>> GetAll()
    {
        var books = await _repository.GetAllAsync();

        var viewModels = books.Select(b => new BookViewModel(b)).ToList();

        if (!viewModels.Any())
        {
            return new BaseResult<List<BookViewModel>>(viewModels, false, "Não existem registros de livros");
        }

        return new BaseResult<List<BookViewModel>>(viewModels);
    }

    public async Task<BaseResult<BookViewModel>> GetById(Guid id)
    {
        var book = await _repository.GetByIdAsync(id);

        if (book is null) return new BaseResult<BookViewModel>(new BookViewModel(book), false, "Este livro não existe em nossa base de dados.");

        var viewModel = new BookViewModel(book);

        return new BaseResult<BookViewModel>(viewModel);
    }

    public async Task<BaseResult<Guid>> Register(RegisterBookInputModel model)
    {
        var book = model.ToEntity();

        await _repository.AddAsync(book);

        return new BaseResult<Guid>(book.Id);
    }
}
