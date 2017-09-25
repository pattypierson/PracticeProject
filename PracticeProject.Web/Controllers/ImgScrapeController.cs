using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeProject.Web.Controllers
{
    [RoutePrefix("scrape")]
    public class ImgScrapeController : Controller
    {
        // GET: ImgScrape
        [Route("images")]
        public ActionResult Index()
        {
            return View();
        }
    }
}