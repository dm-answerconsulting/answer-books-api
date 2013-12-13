using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BooksApi.Service;
using BooksApi.Domain;

namespace BooksApi.Web.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : BaseApiController
    {
        private readonly BookService _service = new BookService();

        // GET api/Books        
        [ResponseType(typeof(IQueryable<BookSummaryRequestObject>))]
        public async Task<IHttpActionResult> GetBooks()
        {
            var books = await _service.GetBooks();

            return ReturnResult(books);
        }

        // GET api/Books/5
        [ResponseType(typeof(BookDetailsRequestObject))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var book = await _service.GetBook(id);

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
