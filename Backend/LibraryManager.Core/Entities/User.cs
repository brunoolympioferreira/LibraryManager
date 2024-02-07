namespace LibraryManager.Core.Entities;
public class User : AggregateRoot
{
    public User(string name, string email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; private set; }
    public string Email { get; private set; }

    public Loan Loan { get; set; }
}
