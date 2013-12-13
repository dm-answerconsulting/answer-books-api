using BooksApi.Data.Models;
using BooksApi.Domain;
using System.Linq;
using Omu.ValueInjecter;

namespace BooksApi.Service.PipesAndFilters
{
    public static class BookObjectMappingExtensions
    {
        public static IQueryable<BookDetailsRequestObject> SelectBookDetailsRequestObjects(this IQueryable<Book> query)
        {
            return query.Select(AsBookDetailsRequestObject).AsQueryable();
        }

        public static IQueryable<BookSummaryRequestObject> SelectBookSummaryRequestObjects(this IQueryable<Book> query)
        {
            return query.Select(AsBookSummaryRequestObject).AsQueryable();
        }

        private static BookDetailsRequestObject AsBookDetailsRequestObject(Book book)
        {
            return new BookDetailsRequestObject().InjectFrom(book) as BookDetailsRequestObject;
        }

        private static BookSummaryRequestObject AsBookSummaryRequestObject(Book book) 
        {
            return new BookSummaryRequestObject().InjectFrom(book) as BookSummaryRequestObject;
        }
    }
}
