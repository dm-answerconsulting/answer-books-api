using System;
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

        public static IQueryable<Book> ForAuthorId(this IQueryable<Book> query, int authorId)
        {
            return query.Where(b => b.AuthorId == authorId);
        }

        public static IQueryable<Book> ForGenre(this IQueryable<Book> query, string genreName)
        {
            return query.Where(b => b.Genre.Name == genreName);
        }

        public static IQueryable<Book> ForPublicationDate(this IQueryable<Book> query, DateTime publicationDate)
        {
            return query.Where(b => b.PublishDate.Date == publicationDate.Date);
        }
    }
}
