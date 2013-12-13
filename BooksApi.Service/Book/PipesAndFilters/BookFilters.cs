using System.Linq;
using BooksApi.Data.Models;

namespace BooksApi.Service.PipesAndFilters
{
    public static class BookFilters
    {
        public static IQueryable<Book> ForId(this IQueryable<Book> query, int id)
        {
            return query.Where(b => b.Id == id);
        }

        public static IQueryable<Book> ForGenre(this IQueryable<Book> query, int genreId)
        {
            return query.Where(b => b.GenreId == genreId);
        }
        public static IQueryable<Book> ExcludeGenre(this IQueryable<Book> query, int genreId)
        {
            return query.Where(b => b.GenreId != genreId);
        }
    }
}
