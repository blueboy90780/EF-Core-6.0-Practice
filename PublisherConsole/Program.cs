// See https://aka.ms/new-console-template for more information

// Reading and Writing Data to the PubDatabase

using PublisherData;
using PublisherDomain;

namespace PublisherConsole;

class Program
{
    public static void Main()
    {
        // Instantiates PubContext class, get it's Database (inherited DbContext) property and then call the EnsureCreated() method.
        using PubContext context = new PubContext();
        context.Database.EnsureCreated(); //This will cause EF Core to read the provider (invoke OnConfiguring()) and connection string then go look to see if the database exist. If it does not, it'll create a new database on the fly
        
        AddAuthor(); // Writes data to the database
        GetAuthors(); // Reading data from the database
        
        // Special Methods
        void GetAuthors()
        {
            // using var context = new PubContext(); // No conflict with variable above?????
            var authors = context.Authors.ToList(); // Turns the entire Authors table into a single collection, this is done through quering
            foreach (var author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }
        
        void AddAuthor()
        {
            Author author = new Author { FirstName = "Julie", LastName = "Lerman" }; // TODO: Explore this syntax thing
            context.Authors.Add(author);
            context.SaveChanges();
        }
    }
}