namespace LibraryManager.Application.DTO.ViewModels;
public record DevolutionResultViewModel() 
{
    public bool IsLate { get; set; }
    public  int DaysOfDelay { get; set; }
}
