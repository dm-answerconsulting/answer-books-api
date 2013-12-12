using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BooksApi.Data.Models;
using BooksApi.Domain;

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
