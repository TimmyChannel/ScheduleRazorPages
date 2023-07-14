using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedule.Models;
namespace Schedule.Service.Controllers
{
    public class ScheduleEventController : Controller
    {
        //private readonly IScheduleEventProvider eventProvider;

        //public ScheduleEventController(IScheduleEventProvider eventProvider)
        //{
        //    this.eventProvider = eventProvider;
        //}
        // GET: ScheduleEventController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ScheduleEventController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScheduleEventController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleEventController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduleEventController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScheduleEventController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ScheduleEventController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScheduleEventController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
