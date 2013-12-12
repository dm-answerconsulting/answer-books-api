using BooksApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BooksApi.Data.Integration
{
    public interface IRepository : IDisposable
    {
        IQueryable<Author> Authors { get; }
        IQueryable<Book> Books { get; }
        IQueryable<Book> BooksWithAuthorAndGenre { get; }
        IQueryable<Genre> Genres { get; }
        T Add<T>(T entity) where T : class;
        IEnumerable<T> Add<T>(IEnumerable<T> entities) where T : class;

        T Remove<T>(T entity) where T : class;
        IEnumerable<T> Remove<T>(IEnumerable<T> entities) where T : class;

        T FindByKey<T>(params object[] key) where T : class;

        IQueryable<T> Query<T>() where T : class;

        int SaveChanges();
    }
}
