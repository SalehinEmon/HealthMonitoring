
using HealthMonitoring.Manager;
using HealthMonitoring.Models;
using System.Web.Mvc;

namespace HealthMonitoring.Controllers
{
    public class AddEntryController : Controller
    {

        public ActionResult Index()
        {
            if(SessionManager.GetUserSession()==null)
            {
                return RedirectToAction("Index","Home");

            }

            TypeOfEntryManager typeOfEntryManager = new TypeOfEntryManager();

            EntryViewModel entryViewModel = new EntryViewModel();

            entryViewModel.AllItems = typeOfEntryManager.GetAllEntryTypeForDropDown();
            entryViewModel.Entry = new Entry();

            return View(entryViewModel);
        }

        [HttpPost]

        public ActionResult Index(Entry entry)
        {
            if (SessionManager.GetUserSession() == null)
            {
                return RedirectToAction("Index", "Home");

            }

            //prepare model for view 

            TypeOfEntryManager typeOfEntryManager = new TypeOfEntryManager();

            EntryViewModel entryViewModel = new EntryViewModel();


            entryViewModel.AllItems = typeOfEntryManager.GetAllEntryTypeForDropDown();
            entryViewModel.Entry = new Entry();


            //add entry to the database using manager
            EntryManager entryManager = new EntryManager();

            User currentUser = SessionManager.GetUserSession();

            entry.UserId = currentUser.Id;

            if(entry.TypeOfEntry == 0)
            {
                ViewBag.msg = "Select a Entry Type";

            }
            else if(entryManager.AddEntry(entry) > 0)
            {

                ViewBag.msg = "Successful";

            }
            else
            {
                ViewBag.msg = "Failed";
            }

            return View(entryViewModel);

        }


    }
}