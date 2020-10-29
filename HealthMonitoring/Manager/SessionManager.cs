using HealthMonitoring.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HealthMonitoring.Manager
{
    public class SessionManager
    {
        public static void SetUserSession(User user)
        {
            HttpContext.Current.Session["user"] = user;

        }

        public static void RemoveUserSession()
        {
            HttpContext.Current.Session["user"] = null;
        }

        public static User GetUserSession()
        {

            return HttpContext.Current.Session["user"] as User;

        }
    }
}