using System.Data.Entity;

namespace Library.Models
{
    public class BddContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public BddContext() : base("name=MyDbConnection")
        {
        }

    }
}