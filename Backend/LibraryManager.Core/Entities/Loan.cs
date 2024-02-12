using System.Configuration;

namespace LibraryManager.Core.Entities;
public class Loan : AggregateRoot
{
    public Loan(Guid userId, Guid bookId)
    {
        UserId = userId;
        BookId = bookId;

        LoanDate = DateTime.Now;
        DevolutionDate = AddDevolutionDate(LoanDate);
    }

    public Guid UserId { get; private set; }
    public Guid BookId { get; private set; }
    public DateTime LoanDate { get; private set; }
    public DateTime DevolutionDate { get; private set; }

    public virtual User User { get; set; }
    public virtual Book Book { get; set; }

    private static DateTime AddDevolutionDate(DateTime loanDate)
    {
        DateTime devolutionDate = loanDate.AddDays(14);

        return devolutionDate;
    }
}
