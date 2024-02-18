using LibraryManager.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Application.DTO.InputModels;
public class DevolutionLoanInputModel
{
    [Required]
    public Guid LoanId { get; set; }
}
