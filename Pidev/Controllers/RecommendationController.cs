using data;
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
        public ActionResult Create(recommendation r)
        {
            try
            {
                serviceRecommendation.Add(r);
                serviceRecommendation.Commit();
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
        public ActionResult Edit(int id, recommendation r)
        {
            try
            {
                var rr = serviceRecommendation.GetById(id);
                rr.recDesc = r.recDesc;
                rr.recDate = r.recDate;
                serviceRecommendation.Update(rr);
                serviceRecommendation.Commit();
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
                var r = serviceRecommendation.GetById(id);
                serviceRecommendation.Delete(r);
                serviceRecommendation.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
