using HealthMonitoring.Manager;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "LogIn");
            }
            return View();
        }
    }
}