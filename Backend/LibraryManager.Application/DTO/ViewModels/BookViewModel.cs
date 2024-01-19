using LibraryManager.Core.Entities;

namespace LibraryManager.Application.DTO.ViewModels;
public class BookViewModel
{
    public BookViewModel(Book? book)
    {
        Id = book?.Id;
        Title = book?.Title;
        Author = book?.Author;
        ISBN = book?.ISBN;
        PublishedYear = book?.PublishedYear;
    }

    public Guid? Id { get; }
    public string? Title { get;}
    public string? Author { get; }
    public string? ISBN { get; }
    public int? PublishedYear { get; }
}
