using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using GCCapstone6Tasklist.Data;
using GCCapstone6Tasklist.Models.Authentication;

namespace GCCapstone6Tasklist.Controllers
{
    public class AuthenticationController : Controller
    {

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Authenticate model)
        {
            if (ModelState.IsValid)
            {
                using (var context = new Capstone6Context())
                {
                    var userList = context.TeamMembers
                        .Where(u => u.Email == model.Email
                            && u.Password == model.Password)
                        .ToList();
                    if (userList.Count() == 1)
                    {
                        FormsAuthentication.SetAuthCookie(model.Email, false);
                        return RedirectToAction("Index", "Task");
                    }
                    else
                    {
                        ModelState.AddModelError("", "The User Name or Password is incorrect.");
                    }
                }
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                //logic to create account
                //make sure there is not already a user with that email
                FormsAuthentication.SetAuthCookie(model.Email, false);
                return RedirectToAction("Index", "Task");
            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}