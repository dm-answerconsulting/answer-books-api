using BooksApi.Data.Models;
using BooksApi.Domain;
using System.Linq;
using Omu.ValueInjecter;

namespace BooksApi.Service.PipesAndFilters
{
    public static class BookObjectMappingExtensions
    {
        public static IQueryable<BookDetailsResponse> SelectBookDetailsResponseObjects(this IQueryable<Book> query)
        {
            return query.Select(AsBookDetailsResponse).AsQueryable();
        }

        public static IQueryable<BookSummaryResponse> SelectBookSummaryResponseObjects(this IQueryable<Book> query)
        {
            return query.Select(AsBookSummaryResponse).AsQueryable();
        }

        private static BookDetailsResponse AsBookDetailsResponse(Book book)
        {
            return new BookDetailsResponse().InjectFrom<FlatLoopValueInjection>(book) as BookDetailsResponse;
        }

        private static BookSummaryResponse AsBookSummaryResponse(Book book) 
        {
            return new BookSummaryResponse().InjectFrom<FlatLoopValueInjection>(book) as BookSummaryResponse;
        }
    }
}