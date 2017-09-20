using PracticeProject.Models.Domain;
using PracticeProject.Models.Requests;
using PracticeProject.Models.Responses;
using PracticeProject.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticeProject.Web.Controllers.ApiControllers
{
    [RoutePrefix("api/team")]
    public class TeamApiController : ApiController
    {
        TeamService teamService = new TeamService();

        // GET ALL api/<controller>
        [Route(""), HttpGet]
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

        // GET BY ID api/<controller>/5
        [Route("{id:int}"), HttpGet]
        public HttpResponseMessage Get(int id)
        {
            try
            {
                ItemResponse<Team> response = new ItemResponse<Team>();
                response.Item = teamService.SelectById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/<controller>
        [Route(""), HttpPost]
        public HttpResponseMessage Post(TeamAddRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = teamService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Put(TeamUpdateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                SuccessResponse response = new SuccessResponse();
                teamService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}