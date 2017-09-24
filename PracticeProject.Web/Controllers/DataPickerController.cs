using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PracticeProject.Web.Controllers
{
    [RoutePrefix("generator")]
    public class DataPickerController : Controller
    {
        // GET: DataPicker
        [Route("randomizer")]
        public ActionResult Random()
        {
            return View();
        }
    }
}