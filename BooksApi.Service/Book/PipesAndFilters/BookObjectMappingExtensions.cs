using BooksApi.Data.Models;
using BooksApi.Domain;
using System.Linq;
using Omu.ValueInjecter;

namespace BooksApi.Service.PipesAndFilters
{
    public static class BookObjectMappingExtensions
    {
        public static IQueryable<BookDetailsResponseObject> SelectBookDetailsResponseObjects(this IQueryable<Book> query)
        {
            return query.Select(AsBookDetailsResponseObject).AsQueryable();
        }

        public static IQueryable<BookSummaryResponseObject> SelectBookSummaryResponseObjects(this IQueryable<Book> query)
        {
            return query.Select(AsBookSummaryResponseObject).AsQueryable();
        }

        private static BookDetailsResponseObject AsBookDetailsResponseObject(Book book)
        {
            return new BookDetailsResponseObject().InjectFrom<FlatLoopValueInjection>(book) as BookDetailsResponseObject;
        }

        private static BookSummaryResponseObject AsBookSummaryResponseObject(Book book) 
        {
            return new BookSummaryResponseObject().InjectFrom<FlatLoopValueInjection>(book) as BookSummaryResponseObject;
        }
    }
}