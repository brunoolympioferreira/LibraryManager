namespace LibraryManager.Core.Entities;
public class Loan : AggregateRoot
{
    public Loan(string userId, string bookId)
    {
        UserId = userId;
        BookId = bookId;

        LoanDate = DateTime.Now;
    }

    public string UserId { get; private set; }
    public string BookId { get; private set; }
    public DateTime LoanDate { get; private set; }

    public User User { get; set; }
    public Book Book { get; set; }
}
