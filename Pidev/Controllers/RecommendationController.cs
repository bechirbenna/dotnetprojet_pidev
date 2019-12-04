using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class RecommendationController : Controller
    {
        ServiceRecommendation serviceRecommendation = new ServiceRecommendation();
        // GET: Recommendation
        public ActionResult Index()
        {
            ViewBag.result = serviceRecommendation.GetMany();
            return View();
        }

        // GET: Recommendation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Recommendation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recommendation/Create
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

        // GET: Recommendation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Recommendation/Edit/5
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

        // GET: Recommendation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Recommendation/Delete/5
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
    }
}
