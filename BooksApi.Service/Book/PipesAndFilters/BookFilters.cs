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
            var from = new DateTime(publicationDate.Year, publicationDate.Month, publicationDate.Day, 0, 0, 0);
            var to = from.AddDays(1).AddMilliseconds(-1);

            return query.ForPublicationDateBetween(from, to);
        }

        public static IQueryable<Book> ForPublicationDateBetween(this IQueryable<Book> query, DateTime dateFrom, DateTime dateTo)
        {
            return query.Where(b => b.PublishDate >= dateFrom && b.PublishDate <= dateTo);
        }
    }
}
