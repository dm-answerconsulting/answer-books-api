using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BooksApi.Service;
using BooksApi.Domain;

namespace BooksApi.Web.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : BaseApiController
    {
        private readonly BookService _service = new BookService();

        // GET api/Books        
        [Route("")]
        [ResponseType(typeof(IQueryable<BookSummaryResponseObject>))]
        public async Task<IHttpActionResult> GetBooks()
        {
            var books = await _service.GetBooks();

            return ReturnResult(books);
        }

        // GET api/Books/5
        [Route("{id:int}")]
        [ResponseType(typeof(BookSummaryResponseObject))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var book = await _service.GetBook(id);

            return ReturnResult(book);
        }

        // GET api/Books/5/details
        [Route("{id:int}/details")]
        [ResponseType(typeof(BookDetailsResponseObject))]
        public async Task<IHttpActionResult> GetBookDetails(int id)
        {
            var book = await _service.GetBookDetails(id);

            return ReturnResult(book);
        }

        // GET api/Books/romance
        [Route("{genre}")]
        [ResponseType(typeof(IQueryable<BookSummaryResponseObject>))]
        public async Task<IHttpActionResult> GetBooksByGenre(string genre)
        {
            var book = await _service.GetBooksByGenre(genre);

            return ReturnResult(book);
        }

        // GET "api/Books/date/2013-12-10"  or  "api/Books/date/2013/12/10"
        [Route("date/{publicationDate:datetime:regex(\\d{4}-\\d{2}-\\d{2})}")] // yyyy-mm-dd
        [Route("date/{*publicationDate:datetime:regex(\\d{4}/\\d{2}/\\d{2})}")] // yyyy/mm/dd (* means use remaining url segments for the parameter)
        [ResponseType(typeof(IQueryable<BookSummaryResponseObject>))]
        public async Task<IHttpActionResult> GetBooks(DateTime publicationDate)
        {
            var book = await _service.GetBooksByPublicationDate(publicationDate);

            return ReturnResult(book);
        }

        // GET api/authors/2/books
        [Route("~/api/authors/{authorId}/books")]
        [ResponseType(typeof(IQueryable<BookSummaryResponseObject>))]
        public async Task<IHttpActionResult> GetBooksByAuthor(int authorId)
        {
            var book = await _service.GetBooksByAuthor(authorId);

            return ReturnResult(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (_service != null)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
