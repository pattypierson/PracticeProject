﻿using PracticeProject.Models.Domain;
using PracticeProject.Models.Requests;
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
        PeopleService peopleService = new PeopleService();

        // GET ALL api/<controller>
        [Route(""), HttpGet]
        public HttpResponseMessage Get()
        {
            try
            {
                ItemsResponse<People> response = new ItemsResponse<People>();
                response.Items = peopleService.SelectAll();
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
                ItemResponse<People> response = new ItemResponse<People>();
                response.Item = peopleService.SelectById(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // POST api/<controller>
        [Route(""), HttpPost]
        public HttpResponseMessage Post(PersonAddRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                ItemResponse<int> response = new ItemResponse<int>();
                response.Item = peopleService.Insert(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // PUT api/<controller>/5
        [Route("{id:int}"), HttpPut]
        public HttpResponseMessage Put(PersonUpdateRequest model)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                SuccessResponse response = new SuccessResponse();
                peopleService.Update(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }

        // DELETE api/<controller>/5
        [Route("{id:int}"), HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                SuccessResponse response = new SuccessResponse();
                peopleService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK, response);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}