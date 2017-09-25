using PracticeProject.Models.Requests;
using PracticeProject.Models.Responses;
using PracticeProject.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PracticeProject.Web.Controllers.ApiControllers
{
    [RoutePrefix("api/scrape")]
    public class ScrapeApiController : ApiController
    {
        ScrapeService scrapeService = new ScrapeService();

        // GET api/<controller>
        [Route("{img}"), HttpGet]
        public HttpResponseMessage Get(string img)
        {
            List<string> response = new List<string>();
            response = scrapeService.Scrape(img);
            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        [Route(), HttpPost]
        public HttpResponseMessage Insert(ImageAddRequest model)
        {
            try
            {
                ItemsResponse<string> response = new ItemsResponse<string>();
                response.Items = scrapeService.InsertImg(model);
                return Request.CreateResponse(HttpStatusCode.OK, response);

            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}