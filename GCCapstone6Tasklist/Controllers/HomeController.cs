using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GCCapstone6Tasklist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Task()
        {
            ViewBag.Message = "Our team's tasks";

            return View();
        }

        public ActionResult AddTasks()
        {
            ViewBag.Message = "New tasks for our team";

            return View();
        }
    }
}