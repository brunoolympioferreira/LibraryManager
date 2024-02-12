namespace LibraryManager.Core.Entities;
public class Book : AggregateRoot
{
    public Book(string title, string author, string iSBN, int publishedYear)
    {
        Title = title;
        Author = author;
        ISBN = iSBN;
        PublishedYear = publishedYear;
    }

    public string Title { get; private set; }
    public string Author { get; private set; }
    public string ISBN { get; private set; }
    public int PublishedYear { get; private set; }

    public virtual Loan Loan { get; set; }
}
