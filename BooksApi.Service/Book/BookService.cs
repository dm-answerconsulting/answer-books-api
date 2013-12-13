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
          
        public Task<IQueryable<BookSummaryResponseObject>> GetBooks()
        {
            var books = _repo.BooksWithAuthorAndGenre.SelectBookSummaryResponseObjects();

            return CreateFacadeTask(books);
        }

        public Task<BookSummaryResponseObject> GetBook(int id) 
        {
            var book = _repo.BooksWithAuthorAndGenre.ForId(id)
                                                    .SelectBookSummaryResponseObjects()
                                                    .FirstOrDefault();

            return CreateFacadeTask(book);
        }

        public Task<BookDetailsResponseObject> GetBookDetails(int id)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForId(id)
                                                    .SelectBookDetailsResponseObjects()
                                                    .FirstOrDefault();

            return CreateFacadeTask(book);
        }

        public Task<IQueryable<BookSummaryResponseObject>> GetBooksByGenre(string genreName)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForGenre(genreName)
                                                    .SelectBookSummaryResponseObjects();

            return CreateFacadeTask(book);
        }

        public Task<IQueryable<BookSummaryResponseObject>> GetBooksByAuthor(int authorId)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForAuthorId(authorId)
                                                    .SelectBookSummaryResponseObjects();

            return CreateFacadeTask(book);
        }

        public Task<IQueryable<BookSummaryResponseObject>> GetBooksByPublicationDate(DateTime publicationDate)
        {
            var book = _repo.BooksWithAuthorAndGenre.ForPublicationDate(publicationDate)
                                                    .SelectBookSummaryResponseObjects();

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