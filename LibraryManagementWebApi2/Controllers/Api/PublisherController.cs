
using Services.Interfaces;
using Services.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryManagementWebApi2.Controllers.Api
{
    [RoutePrefix("api/publishers")]
    public class PublisherController : ApiController
    {
        private readonly IPublisherService publisherService;

        public PublisherController(IPublisherService publisherService)
        {
            this.publisherService = publisherService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var results = publisherService.GetAll().ToList();
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
            PublisherModel result = publisherService.GetById(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("{id:min(1)}")]
        public IHttpActionResult Updatepublisher(int id, [FromBody]PublisherModel publisher)
        {
            PublisherModel result = publisherService.GetById(id);
            if (result != null)
            {
                var updatePublisher = publisherService.UpdatePublisher( id ,publisher);
                if (updatePublisher)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertPublisher([FromBody]PublisherModel publisher)
        {
            var insertPublisher = publisherService.InsertPublisher(publisher);
            if (insertPublisher)
            {
                return Ok();
            }

            return Content(HttpStatusCode.BadRequest, "Bad object");
        }

        [HttpDelete]
        [Route("{id:min(1)}")]
        public IHttpActionResult DeletePublisher(int id)
        {
            var result = publisherService.Delete(id);

            if (result)
            {
                return Ok();
            }

            return Content(HttpStatusCode.ExpectationFailed, "Deleting Failed");
        }
    }
}
