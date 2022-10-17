namespace PublisherDomain;

public class Author
{
    // Constructor, initializes a list of books
    public Author()
    {
        Books = new List<Book>(); //Instantiates the List<Book> type
    }

    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public List<Book> Books { get; set; }
}