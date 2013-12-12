using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using System.Linq.Expressions;
using BooksApi.Service;
using BooksApi.Domain;

namespace BooksApi.Web.API.Controllers
{
    [RoutePrefix("api/books")]
    public class BooksController : ApiController
    {
        private readonly BookService service = new BookService();
                
        // GET api/Books        
        [ResponseType(typeof(IQueryable<BookTransferObject>))]
        public async Task<IHttpActionResult> GetBooks()
        {
            var books = await service.GetBooks();

            return ReturnResult(books);
        }

        // GET api/Books/5
        [ResponseType(typeof(BookTransferObject))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var book = await service.GetBook(id);

            return ReturnResult(book);
        }

        private IHttpActionResult ReturnResult<T>(T content) 
        {
            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }

        protected override void Dispose(bool disposing)
        {
            if (service != null)
            { 
                service.Dispose(); 
            }
            base.Dispose(disposing);
        }
    }
}