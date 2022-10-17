// See https://aka.ms/new-console-template for more information

// Reading and Writing Data to the PubDatabase

using PublisherData;


namespace PublisherConsole;

class Program
{
    public static void Main()
    {
        // Instantiates PubContext class, get it's Database (inherited DbContext) property and then call the EnsureCreated() method. This will cause EF Core to read the provider and connection string defined in the PubContext class and then go look to see if the database exist. If it does not, it'll read the context, determine what the database should look like and create one on the fly
        using PubContext context = new PubContext(); // TODO: Look up on what the using statement is really about
        context.Database.EnsureCreated();

        GetAuthors();
        
        // Method
        void GetAuthors()
        {
            // Creates a new instance of PubContext
            using var context = new PubContext();
            
            // Converts the authors table into a collection List<T>
            var authors = context.Authors.ToList(); // Weird yellow icon on "ToList" is apparently a LINQ method

            foreach (var author in authors)
            {
                Console.WriteLine(author.FirstName + " " + author.LastName);
            }
        }
    }
}