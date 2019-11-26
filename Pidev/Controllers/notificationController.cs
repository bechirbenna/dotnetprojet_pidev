using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class notificationController : Controller
    {
        // GET: notification
        public ActionResult Index()
        {
            return View();
        }

        // GET: notification/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: notification/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: notification/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: notification/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: notification/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: notification/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: notification/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public static string nbNotif()
        {
            HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/notifications/NBnotif").Result;
            
            var a = response.Content.ReadAsStringAsync().Result;

            return a ;
        }

        public static IEnumerable<notification> getListNotif()
        {
             HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/notifications/Type/Manager").Result;
             return response.Content.ReadAsAsync<IEnumerable<notification>>().Result;
        }

    }
}
