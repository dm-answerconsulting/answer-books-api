using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using BooksApi.Data.Models.Mapping;

namespace BooksApi.Data.Models
{
    public partial class BooksApiContext : DbContext
    {
        static BooksApiContext()
        {
            Database.SetInitializer<BooksApiContext>(null);
        }

        public BooksApiContext()
            : base("Name=BooksApiContext")
        {
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AuthorMap());
            modelBuilder.Configurations.Add(new BookMap());
            modelBuilder.Configurations.Add(new GenreMap());
        }
    }
}
