
using Services.Interfaces;
using Services.Models;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryManagementWebApi2.Controllers.Api
{
    [RoutePrefix("api/lendings")]
    public class LendingController : ApiController
    {
        private readonly ILendingService lendingService;

        public LendingController(ILendingService lendingService)
        {
            this.lendingService = lendingService;
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetAll()
        {
            var results = lendingService.GetAll().ToList();
            if (results.Count() > 0)
            {
                return Ok(results);

            }

            return NotFound();
        }

        [HttpGet]
        [Route("lent")]
        public IHttpActionResult GetAllLent()
        {
            var results = lendingService.GetAll().ToList();
            results = results.Where(x => x.LendingDate != null).ToList();

            if (results.Count() > 0)
            {
                return Ok(results);

            }

            return NotFound();
        }

        [HttpGet]
        [Route("returned")]
        public IHttpActionResult GetAllReturned()
        {
            var results = lendingService.GetAll().ToList();
            results = results.Where(x => x.LendingDate != null && x.ReturnDate != null).ToList();

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
            LendingModel result = lendingService.GetById(id);
            if (result != null)
                return Ok(result);
            return NotFound();
        }


        [HttpPut]
        [Route("{id:min(1)}")]
        public IHttpActionResult UpdateLending(int id, [FromBody]LendingModel lending)
        {
            LendingModel result = lendingService.GetById(id);
            if (result != null)
            {
                var updateLending = lendingService.UpdateLending( id ,lending);
                if (updateLending)
                {
                    return Ok();
                }
            }
            return NotFound();
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult InsertLending([FromBody]LendingModel lending)
        {
            var insertLending = lendingService.InsertLending(lending);
            if (insertLending)
            {
                return Ok();
            }

            return Content(HttpStatusCode.BadRequest, "Bad object");
        }

    }
}
