﻿using BooksApi.Data;
using BooksApi.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksApi.Data.Integration
{
    public class Repository : IRepository
    {
        private readonly BooksApiContext _db = new BooksApiContext();

        public IQueryable<Author> Authors
        {
            get
            {
                return _db.Authors.AsQueryable();
            }
        }
        public IQueryable<Book> Books
        {
            get
            {
                return _db.Books.AsQueryable();
            }
        }
        public IQueryable<Book> BooksWithAuthorAndGenre
        {
            get
            {
                return _db.Books
                          .Include("Author")
                          .Include("Genre")
                          .AsQueryable();
            }
        }
        public IQueryable<Genre> Genres
        {
            get
            {
                return _db.Genres.AsQueryable();
            }
        }
        
        /* --------------------------------- */
        /* BELOW HERE - Generic Don't Change */
        /* --------------------------------- */

        public virtual T Add<T>(T entity) where T : class
        {
            return _db.Set<T>().Add(entity);
        }

        public virtual IEnumerable<T> Add<T>(IEnumerable<T> entities) where T : class
        {
            var result = new List<T>();

            foreach (var entity in entities)
            {
                result.Add(Add(entity));
            }

            return result;
        }

        public virtual T Remove<T>(T entity) where T : class
        {
            return _db.Set<T>().Remove(entity);
        }

        public virtual IEnumerable<T> Remove<T>(IEnumerable<T> entities) where T : class
        {
            var result = new List<T>();

            foreach (var entity in entities)
            {
                result.Add(Remove(entity));
            }

            return result;
        }

        public virtual T FindByKey<T>(params object[] key) where T : class
        {
            return _db.Set<T>().Find(key);
        }

        public virtual IQueryable<T> Query<T>() where T : class
        {
            return _db.Set<T>().AsQueryable();
        }

        public virtual int SaveChanges()
        {
            return _db.SaveChanges();
        }

        public virtual void Dispose()
        {
            _db.Dispose();
        }
    }
}