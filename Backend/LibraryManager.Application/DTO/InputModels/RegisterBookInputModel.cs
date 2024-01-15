using LibraryManager.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Application.DTO.InputModels;
public class RegisterBookInputModel
{
    [Required(ErrorMessage = "Título do livro é obrigatório")]
    public string Title { get; set; }
    [Required(ErrorMessage = "Autor do livro é obrigatório")]
    public string Author { get; set; }
    [Required(ErrorMessage = "ISBN é obrigatório")]
    public string ISBN { get; set; }
    [Required(ErrorMessage = "Ano de publicação é obrigatório")]
    public int PublishedYear { get; set; }

    public Book ToEntity() => new(Title, Author, ISBN, PublishedYear);
}
