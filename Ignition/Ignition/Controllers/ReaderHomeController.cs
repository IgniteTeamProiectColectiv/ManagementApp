using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ignition.Controllers
{
    public class ReaderHomeController : Controller
    {
        // GET: ReaderHome
        [System.Web.Http.Route("ReaderHome")]
        [HttpPost]
        public ActionResult ReaderHome(String username)
        {
            ViewBag.Title = username + "ReaderHome Page";

            return View();
        }
    }
}