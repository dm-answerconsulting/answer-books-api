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

        public Task<BookSummaryRequestObject> GetBook(int id) 
        {
            var book = _repo.BooksWithAuthorAndGenre.ForId(id)
                                                    .SelectBookSummaryRequestObjects()
                                                    .FirstOrDefault();

            return CreateFacadeTask(book);
        }

        public Task<BookDetailsRequestObject> GetBookDetails(int id)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForId(id)
                                                    .SelectBookDetailsRequestObjects()
                                                    .FirstOrDefault();

            return CreateFacadeTask(book);
        }

        public Task<IQueryable<BookSummaryRequestObject>> GetBooksByGenre(string genreName)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForGenre(genreName)
                                                    .SelectBookSummaryRequestObjects();

            return CreateFacadeTask(book);
        }

        public Task<IQueryable<BookSummaryRequestObject>> GetBooksByAuthor(int authorId)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForAuthorId(authorId)
                                                    .SelectBookSummaryRequestObjects();

            return CreateFacadeTask(book);
        }

        public Task<IQueryable<BookSummaryRequestObject>> GetBooksByPublicationDate(DateTime publicationDate)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForPublicationDate(publicationDate)
                                                    .SelectBookSummaryRequestObjects();

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