
using Services.Interfaces;
using Services.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryManagementWebApi2.Controllers.Api
{
    [RoutePrefix("api/clients")]
    public class ClientController : ApiController
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {
            this.clientService = clientService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var results = clientService.GetAll().ToList();
            if (results.Count > 0)
            {
                return Ok(results);

            }

            return NotFound();
        }

        [HttpGet]
        [Route("{id:min(1)}")]
        public IHttpActionResult GetById(int id)
        {
            ClientModel result = clientService.GetById(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("{id:min(1)}")]
        public IHttpActionResult UpdateClient(int id, [FromBody]ClientModel book)
        {
            ClientModel result = clientService.GetById(id);
            if (result != null)
            {
                var updateClient = clientService.UpdateClient( id ,book);
                if (updateClient)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertBook([FromBody]ClientModel book)
        {
            var insertClient = clientService.InsertClient(book);
            if (insertClient)
            {
                return Ok();
            }

            return Content(HttpStatusCode.BadRequest, "Bad object");
        }

        [HttpDelete]
        [Route("{id:min(1)}")]
        public IHttpActionResult DeleteClient(int id)
        {
            var result = clientService.Delete(id);

            if (result)
            {
                return Ok();
            }

            return Content(HttpStatusCode.ExpectationFailed, "Deleting Failed");
        }
    }
}
