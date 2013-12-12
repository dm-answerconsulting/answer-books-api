using BooksApi.Data.Models;
using BooksApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Omu.ValueInjecter;

namespace BooksApi.Service.PipesAndFilters
{
    public static class BookObjectMappingExtensions
    {
        public static IQueryable<BookTransferObject> SelectBookTransferObjects(this IQueryable<Book> query)
        {
            return query.Select(CreateBookTransferObject).AsQueryable();
        }

        private static BookTransferObject CreateBookTransferObject(Book book) 
        {
            return new BookTransferObject().InjectFrom(book) as BookTransferObject;
        }
    }
}
