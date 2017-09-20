using PracticeProject.Models.Domain;
using PracticeProject.Models.Responses;
using PracticeProject.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticeProject.Web.Controllers.ApiControllers
{
    [Route("api/team")]
    public class TeamApiController : ApiController
    {
        TeamService teamService = new TeamService();

        // GET ALL api/<controller>
        public HttpResponseMessage Get()
        {
            try
            {
                ItemsResponse<Team> response = new ItemsResponse<Team>();
                response.Items = teamService.SelectAll();
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