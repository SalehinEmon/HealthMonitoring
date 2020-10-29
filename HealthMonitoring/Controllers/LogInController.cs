using HealthMonitoring.Manager;
using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class LogInController : Controller
    {
        // GET: LogIn
        public ActionResult Index()
        {
            

            if(SessionManager.GetUserSession() != null)
            {
                //ViewBag.msg = "logged in user found";
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        [HttpPost]
        
        public ActionResult Index(string email,string password)
        {
            if (SessionManager.GetUserSession() != null)
            {
                //ViewBag.msg = "logged in user found";
                return RedirectToAction("Index", "Home");
            }

            UserManager userManager = new UserManager();

            User user = userManager.FindUserByEmailAndPassword(email, password);

            if(user != null)
            {
                SessionManager.SetUserSession(user);

                ViewBag.msg = "Successful";
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.msg = "Wrong Password Or Email!";
            }
            return View();
        }
    }
}