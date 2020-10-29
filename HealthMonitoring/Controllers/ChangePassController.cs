using HealthMonitoring.Context;
using HealthMonitoring.Manager;
using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class ChangePassController : Controller
    {
        // GET: EditProfile
        public ActionResult Index()
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "Home");

            }
            return View();
        }


        [HttpPost]

        public ActionResult Index(string oldpassword,string newpassword,string newpasswordagain)
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "Home");

            }

            if (newpassword != newpasswordagain)
            {
                ViewBag.msg = "Password doesn't match";
            }
            else
            {


                using (HealthMonitorContext healthMonitorContext = new HealthMonitorContext())
                {
                    User CurrentUser = SessionManager.GetUserSession();

                    User user = healthMonitorContext.User
                        .FirstOrDefault(u => u.Email == CurrentUser.Email);

                    if (user != null)
                    {
                        newpassword = PasswordManager.GenerateSHA256String(newpassword);

                        user.Password = newpassword;
                        healthMonitorContext.SaveChanges();
                    }
                }
            }
            return View();
        }
    }

}