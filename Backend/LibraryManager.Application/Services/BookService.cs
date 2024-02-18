using LibraryManager.Application.DTO.InputModels;
using LibraryManager.Application.DTO.ViewModels;
using LibraryManager.Core.Repositories;

namespace LibraryManager.Application.Services;
public class BookService : IBookService
{
    private readonly IBookRepository _repository;
    private readonly IUserRepository _userRepository;
    private readonly ILoanRepository _loanRepository;
    public BookService(IBookRepository repository, IUserRepository userRepository, ILoanRepository loanRepository)
    {
        _repository = repository;
        _userRepository = userRepository;
        _loanRepository = loanRepository;
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

    public async Task<BaseResult> Delete(Guid id)
    {
        await _repository.DeleteAsync(id);

        return new BaseResult();
    }

    public async Task<BaseResult<Guid>> AddLoan(LoanInputModel model)
    {
        BaseResult result = await LoanValidation(model);

        if (result.Success == false)
        {
            var guid = new Guid();
            return new BaseResult<Guid>(guid, false, result.Message);
        }

        var loan = model.ToEntity();

        await _loanRepository.AddAsync(loan);

        return new BaseResult<Guid>(loan.Id);
    }

    public async Task<BaseResult<DevolutionResultViewModel>> AddDevolutionLoan(DevolutionLoanInputModel model)
    {
        var loan = await _loanRepository.GetByIdAsync(model.LoanId);
        DevolutionResultViewModel viewModel = new();

        if (loan is null)
            return new BaseResult<DevolutionResultViewModel>(viewModel, false, "Empréstimo não cadastrado na base de dados");

        (bool isLate, int diffDate) = CalculateDevolutionDate(loan.DevolutionDate);

        if (isLate)
            return new BaseResult<DevolutionResultViewModel>(viewModel with { IsLate = true, DaysOfDelay = diffDate}, true, $"Devolução de livro com {diffDate} dias de atraso");

        return new BaseResult<DevolutionResultViewModel>(viewModel with { IsLate = false, DaysOfDelay = 0} , true, "Devolução em dia");
    }

    private async Task<BaseResult> LoanValidation(LoanInputModel model)
    {
        var user = await _userRepository.GetByIdAsync(model.UserId);
        var book = await _repository.GetByIdAsync(model.BookId);

        if (user is null)
        {
            return new BaseResult(false, "Usuário não existe no banco de dados");
        }
        else if(book is null)
        {
            return new BaseResult(false, "Livro não existe no banco de dados");
        }

        return new BaseResult();
    }

    private static (bool,int) CalculateDevolutionDate(DateTime devolutionDate)
    {
        var diffDateDevolution = (DateTime.Now - devolutionDate).Days;
        bool isLate = diffDateDevolution > 0;

        return (isLate, diffDateDevolution);
    }
}
