
using Services.Interfaces;
using Services.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryManagementWebApi2.Controllers.Api
{
    [RoutePrefix("api/bookcopies")]
    public class BookCopyController : ApiController
    {
        private readonly IBookCopyService bookCopyService;

        public BookCopyController(IBookCopyService bookCopyService)
        {
            this.bookCopyService = bookCopyService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var results = bookCopyService.GetAll().ToList();
            if(results.Count() > 0)
            {
                return Ok(results);

            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id:min(1)}/library")]
        public IHttpActionResult GetAllByLibraryId(int id)
        {
            var results = bookCopyService.GetAllByLibraryId(id).ToList();
            if (results != null)
            {
                return Ok(results);

            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            BookCopyModel result = bookCopyService.GetById(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("{id:min(1)}")]
        public IHttpActionResult UpdateBookCopy(int id, [FromBody]BookCopyModel bookCopy)
        {
            BookCopyModel result = bookCopyService.GetById(id);
            if (result != null)
            {
                var updateBookCopy = bookCopyService.UpdateBookCopy( id ,bookCopy);
                if (updateBookCopy)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertBookCopy([FromBody]BookCopyModel bookCopy)
        {
            var insertBookCopy = bookCopyService.InsertBookCopy(bookCopy);
            if (insertBookCopy)
            {
                return Ok();
            }

            return Content(HttpStatusCode.BadRequest, "Bad object");
        }

        [HttpDelete]
        [Route("{id:min(1)}")]
        public IHttpActionResult DeletebookCopy(int id)
        {
            var result = bookCopyService.Delete(id);

            if (result)
            {
                return Ok();
            }

            return Content(HttpStatusCode.ExpectationFailed, "Deleting Failed");
        }
    }
}
