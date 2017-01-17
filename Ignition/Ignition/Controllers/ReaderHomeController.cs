using System;
using System.Web.Mvc;

namespace Ignition.Controllers
{
    public class ReaderHomeController : Controller
    {
        // GET: ReaderHome
        [System.Web.Http.Route("ReaderHome")]
        //[HttpPost]
        public ActionResult Index()
        {

            if (Session["role"].Equals("1"))
            {
                string username = Session["username"].ToString();
                ViewBag.Title = username + "ReaderHome Page";

                return View();
            }

            return null;
        }
    }
}