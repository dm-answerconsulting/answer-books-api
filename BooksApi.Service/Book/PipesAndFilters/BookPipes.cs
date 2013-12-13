using System.Linq;
using BooksApi.Data.Models;

namespace BooksApi.Service.PipesAndFilters
{
    public static class BookPipes
    {        
        public static IQueryable<Book> Fantasy(this IQueryable<Book> query)
        {
            return query.ForGenre(1);
        }
        public static IQueryable<Book> Romance(this IQueryable<Book> query)
        {
            return query.ForGenre(2);
        }

        public static IQueryable<Book> ExcludingFantasy(this IQueryable<Book> query)
        {
            return query.ExcludeGenre(1);
        }
        public static IQueryable<Book> ExcludingRomance(this IQueryable<Book> query)
        {
            return query.ExcludeGenre(2);
        }
    }
}
