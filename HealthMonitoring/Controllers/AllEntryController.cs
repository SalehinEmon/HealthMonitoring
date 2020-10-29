using HealthMonitoring.Manager;
using HealthMonitoring.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class AllEntryController : Controller
    {
        // GET: AllEntry
        public ActionResult Index()
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "LogIn");
            }

            List<Entry> entrys = new List<Entry>();

            TypeOfEntryManager typeOfEntryManager = new TypeOfEntryManager();

            ViewBag.typeOfEntryDropdown = typeOfEntryManager.GetAllEntryTypeForDropDown();

            return View(entrys);
        }

        [HttpPost]
        public ActionResult Index(EntryFilter entryFilter)
        {

            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "LogIn");
            }

            if (entryFilter.TypeOfEntry == 0)
            {
                ViewBag.msg = "Please Select a type ";
            }

            EntryManager entryManager = new EntryManager();
            TypeOfEntryManager typeOfEntryManager = new TypeOfEntryManager();

            User currentUser = SessionManager.GetUserSession();

            entryFilter.UserId = currentUser.Id;

            List<Entry> entrys = entryManager.GetEntryByFilter(entryFilter);

            ViewBag.typeOfEntryDropdown = typeOfEntryManager.GetAllEntryTypeForDropDown();

            if(typeOfEntryManager.GetTypeOfEntryById(entryFilter.TypeOfEntry)!= null)
            {
                ViewBag.NameOfEntry = typeOfEntryManager
                    .GetTypeOfEntryById(entryFilter.TypeOfEntry).Name;

            }

            else
            {
                ViewBag.NameOfEntry = " ";
            }
            

            return View(entrys);
        }
    }
}