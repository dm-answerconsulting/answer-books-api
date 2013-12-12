using BooksApi.Data.Integration;
using BooksApi.Data;
using BooksApi.Data.Models;
using BooksApi.Domain;
using BooksApi.Service.PipesAndFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace BooksApi.Service
{
    public class BookService : IDisposable
    {
        private readonly IRepository repo = new Repository();
          
        public async Task<IQueryable<BookTransferObject>> GetBooks()
        {
            return repo.BooksWithAuthorAndGenre.SelectBookTransferObjects();
        }

        public async Task<BookTransferObject> GetBook(int id) 
        {
            return repo.BooksWithAuthorAndGenre.ForId(id)
                                               .SelectBookTransferObjects()
                                               .FirstOrDefault();
        }
        
        public void Dispose()
        {
            if (repo != null)
            {
                repo.Dispose(); 
            }
        }
    }
}