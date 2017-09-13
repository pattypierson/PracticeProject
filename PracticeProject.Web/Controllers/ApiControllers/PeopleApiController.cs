using PracticeProject.Models.Domain;
using PracticeProject.Models.Responses;
using PracticeProject.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticeProject.Web.Controllers.ApiControllers
{
    [RoutePrefix("api/people")]
    public class PeopleApiController : ApiController
    {
        private IPeopleService _peopleService;

        public PeopleApiController(IPeopleService PeopleService)
        {
            _peopleService = PeopleService;
        }

        // GET ALL api/<controller>
        [Route(""), HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ItemsResponse<People> response = new ItemsResponse<People>();
                response.Items = _peopleService.Get();
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}