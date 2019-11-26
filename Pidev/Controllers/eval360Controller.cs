using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class eval360Controller : Controller
    {
        // GET: eval360
        public ActionResult Index()
        {
            return View();
        }

        // GET: eval360/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: eval360/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: eval360/Create
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

        // GET: eval360/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: eval360/Edit/5
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

        // GET: eval360/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: eval360/Delete/5
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

        public static eval360Models getFirstEval()
        {
            HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/evaluation360/FirstOne").Result;

            var res = response.Content.ReadAsAsync<eval360Models>().Result;
            eval360Models ev = new eval360Models();
            ev = res;
            return ev;
        }

        public static eval360Models getSecondEval()
        {
            HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/evaluation360/SecondOne").Result;

            var res = response.Content.ReadAsAsync<eval360Models>().Result;
            eval360Models ev = new eval360Models();
            ev = res;
            return ev;
        }

        public static eval360Models getThirdEval()
        {
            HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/evaluation360/ThirdOne").Result;

            var res = response.Content.ReadAsAsync<eval360Models>().Result;
            eval360Models ev = new eval360Models();
            ev = res;
            return ev;
        }

        public static IEnumerable<eval360Models> getAfterThree()
        {
            HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/evaluation360/ListEvalAfterThree").Result;
            return response.Content.ReadAsAsync<IEnumerable<eval360Models>>().Result;
        }


    }
}
