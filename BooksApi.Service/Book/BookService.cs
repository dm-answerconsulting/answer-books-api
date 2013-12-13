using BooksApi.Data.Integration;
using BooksApi.Domain;
using BooksApi.Service.Base;
using BooksApi.Service.PipesAndFilters;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApi.Service
{
    public class BookService : BaseTaskResultService, IDisposable
    {
        private readonly IRepository _repo = new Repository();
          
        public Task<IQueryable<BookSummaryRequestObject>> GetBooks()
        {
            var books = _repo.BooksWithAuthorAndGenre.SelectBookSummaryRequestObjects();

            return CreateFacadeTask(books);
        }

        public Task<BookDetailsRequestObject> GetBook(int id) 
        {
            var book = _repo.BooksWithAuthorAndGenre.ForId(id)
                                                    .SelectBookDetailsRequestObjects()
                                                    .FirstOrDefault();

            return CreateFacadeTask(book);
        }
        
        public void Dispose()
        {
            if (_repo != null)
            {
                _repo.Dispose(); 
            }
        }
    }
}