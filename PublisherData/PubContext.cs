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
    public string DbPath { get; }

    public PubContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = System.IO.Path.Join(path, "PublisherDB.db");
    }

    // The following configures EF to create a Sqlite database file in the
    // special "local" folder for your platform.
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}"); // apparently connectionString is literally a file path to where the database will be made wrapped with 'Data Source='
}