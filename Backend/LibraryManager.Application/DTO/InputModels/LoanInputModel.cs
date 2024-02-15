using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Application.DTO.InputModels;
public class LoanInputModel
{
    [Required]
    public Guid UserId { get; set; }
    [Required]
    public Guid BookId { get; set; }

    public Core.Entities.Loan ToEntity() => new(UserId, BookId);
}
