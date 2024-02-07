using LibraryManager.Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace LibraryManager.Application.DTO.InputModels;
public class RegisterUserInputModel
{
    [Required(ErrorMessage = "Nome do usuário é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "E-mail do usuário é obrigatório")]
    public string Email { get; set; }

    public User ToEntity() => new(Name, Email);
}
