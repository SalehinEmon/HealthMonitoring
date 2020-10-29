using HealthMonitoring.Manager;
using HealthMonitoring.Models;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class TypeOfEntryController : Controller
    {
        // GET: TypeOfEntry
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

            return View();
        }

        public ActionResult Add()
        {
            if(SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (SessionManager.GetUserSession().Role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new TypeOfEntry());
        }

        [HttpPost]

        public ActionResult Add(TypeOfEntry typeOfEntry)
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (SessionManager.GetUserSession().Role != "admin")
            {
                return RedirectToAction("Index", "Home");
            }


            if (ModelState.IsValid)
            {

                TypeOfEntryManager typeOfEntryManager = new TypeOfEntryManager();

                if(string.IsNullOrEmpty(typeOfEntry.Name))
                {
                    ViewBag.msg = "Empty string is not allowed";

                }
                else if (typeOfEntryManager.AddType(typeOfEntry) > 0)
                {
                    ViewBag.msg = "Successful";
                }
                else
                {
                    ViewBag.msg = "Failed";
                }

            }



            return View(typeOfEntry);
        }

    }
}