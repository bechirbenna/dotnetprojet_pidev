using data;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class CalendarController : Controller
    {

        ServiceCalendar calendarService = new ServiceCalendar();
        // GET: Calendar
        public ActionResult Index()
        {
            return View(calendarService.GetMany());
        }

        // GET: Calendar/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Calendar/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calendar/Create
        [HttpPost]
        public ActionResult Create(calendar calendar)
        {
            try
            {
                // TODO: Add insert logic here
                calendarService.Add(calendar);
                calendarService.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calendar/Edit/5
        public ActionResult Edit(int id)
        {
            calendar calendar = calendarService.GetById(id);
            ViewBag.dateDebut = calendar.DateDebut;
            ViewBag.dateFin = calendar.DateFin;
            return View(calendar);
        }

        // POST: Calendar/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                calendar calendar = calendarService.GetById(id);
                calendarService.Update(calendar);
                calendarService.Commit();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Calendar/Delete/5
        public ActionResult Delete(int id)
        {
           calendar calendar =  calendarService.GetById(id);
            calendarService.Delete(calendar);
            calendarService.Commit();
            return RedirectToAction("Index");
        }

   
    }
}
