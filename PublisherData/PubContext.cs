// DbContext resides in this namespace
using Microsoft.EntityFrameworkCore;
using PublisherDomain;

// Class "PubContext" part of this namespace
namespace PublisherData;

public class PubContext:DbContext
{
    // Instance Field
    // EF Core will presume by it's conventions, that the table name match the DbSets name. Therefore, "Authors" and "Books" are 2 tables in a database. This is a way to let EF Core knows about the classes it will be interacting with
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    
    // With EF Core, you need to tell the context what database provider you use and explicitly give it a connection string
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // UseSQLServer accepts a connection strings as it's argument which is "string used to open a SQL Server database."
        optionsBuilder.UseSqlServer(
            "Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = PubDatabase"); // Where PubDataBase is the database's name
    }
}