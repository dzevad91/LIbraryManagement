
using Services.Interfaces;
using Services.Models;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace LibraryManagementWebApi2.Controllers.Api
{
    [RoutePrefix("api/libraries")]
    public class LibraryController : ApiController
    {
        private readonly ILibraryService libraryService;

        public LibraryController(ILibraryService libraryService)
        {
            this.libraryService = libraryService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var results = libraryService.GetAll().ToList();
            if (results.Count() > 0 )
            {
                return Ok(results);

            }

            return NotFound(); 
        }

        [HttpGet]
        [Route("{id:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            var result = libraryService.GetAllLibraryDetails(id).ToList();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return Content(HttpStatusCode.BadRequest, "failed");
        }


        [HttpPut]
        [Route("{id:min(1)}")]
        public IHttpActionResult UpdateLibrary([FromBody]LibraryModel library)
        {
            LibraryModel result = libraryService.GetById(library.Id);
            if (result != null)
            {
                var updateLibrary = libraryService.UpdateLibrary(library);
                if (updateLibrary)
                {
                    return Content( HttpStatusCode.OK , "success");
                }
            }
            return Content(HttpStatusCode.BadRequest, "failed");
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertLibrary([FromBody]LibraryModel library)
        {
            var insertLibrary = libraryService.InsertLibrary(library);
            if (insertLibrary)
            {
                return Content(HttpStatusCode.Created, "success");
            }

            return Content(HttpStatusCode.BadRequest, "failed");
        }

        [HttpDelete]
        [Route("{id:min(1)}")]
        public IHttpActionResult DeleteLibrary(int id)
        {
            var result = libraryService.Delete(id);

            if (result)
            {
                return Content(HttpStatusCode.OK, "success");
            }

            return Content(HttpStatusCode.BadRequest, "Deleting Failed");
        }

    }
}
