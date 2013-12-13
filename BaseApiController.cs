using System.Web.Http;

namespace BooksApi.Web.Controllers
{
    public class BaseApiController : ApiController
    {
        protected IHttpActionResult ReturnResult<T>(T content)
        {
            if (content == null)
            {
                return NotFound();
            }

            return Ok(content);
        }
    }
}