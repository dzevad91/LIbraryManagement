
using Services.Interfaces;
using Services.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryManagementWebApi2.Controllers.Api
{
    [RoutePrefix("api/books")]
    public class BookController : ApiController
    {
        private readonly IBookService bookService;

        public BookController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var results = bookService.GetAll().ToList();
            if (results.Count() > 0)
            {
                return Ok(results);

            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            BookModel result = bookService.GetById(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("{id:min(1)}")]
        public IHttpActionResult UpdateBook(int id, [FromBody]BookModel book)
        {
            BookModel result = bookService.GetById(id);
            if (result != null)
            {
                var updateBook = bookService.UpdateBook( id ,book);
                if (updateBook)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertBook([FromBody]BookModel book)
        {
            var insertBook = bookService.InsertBook(book);
            if (insertBook)
            {
                return Ok();
            }

            return Content(HttpStatusCode.BadRequest, "Bad object");
        }

        [HttpDelete]
        [Route("{id:min(1)}")]
        public IHttpActionResult DeleteBook(int id)
        {
            var result = bookService.Delete(id);

            if (result)
            {
                return Ok();
            }

            return Content(HttpStatusCode.ExpectationFailed, "Deleting Failed");
        }
    }
}
