using HealthMonitoring.Manager;
using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class ProfileController : Controller
    {
        // GET: Profile}

        public ActionResult ShowProfile()
        {
            User loggedInUser = SessionManager.GetUserSession();

            if (loggedInUser == null)
            {
                return RedirectToAction("Index", "Home");

            }

            if(loggedInUser.DateOfBirth.ToString("dd-mm-yyyy") != "01-00-0001")
            {
                ViewBag.age = DateOfBirth.GetAgeFromDateofBirth(loggedInUser.DateOfBirth).ToString("yy");
            }
            
            return View(loggedInUser);
        }
    }
}