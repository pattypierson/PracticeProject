using PracticeProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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


    }
}