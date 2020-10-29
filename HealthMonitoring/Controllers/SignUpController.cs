using HealthMonitoring.Manager;
using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class SignUpController : Controller
    {
        // GET: SignUp
        public ActionResult Index()
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (SessionManager.GetUserSession().Role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            List<SelectListItem> userRoleType = new List<SelectListItem>()
            {
                new SelectListItem{ Text="--Select--",Value="0"},
                new SelectListItem{ Text="Admin",Value="admin"},
                new SelectListItem{ Text="Normal User",Value="user"}
            };

            ViewBag.userRoleType = userRoleType;

            return View(new User());
        }

        [HttpPost]

        public ActionResult Index(User user)
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (SessionManager.GetUserSession().Role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            List<SelectListItem> userRoleType = new List<SelectListItem>()
            {
                new SelectListItem{ Text="--Select--",Value="0"},
                new SelectListItem{ Text="Admin",Value="admin"},
                new SelectListItem{ Text="Normal User",Value="user"}
            };

            ViewBag.userRoleType = userRoleType;


            if (ModelState.IsValid)
            {
                UserManager userManager = new UserManager();

                if(userManager.AddUser(user)>0)
                {
                    ViewBag.msg = "Success";

                }
                else
                {
                    ViewBag.msg = "Failed";
                }

            }
            return View(user);
        }
    }
}