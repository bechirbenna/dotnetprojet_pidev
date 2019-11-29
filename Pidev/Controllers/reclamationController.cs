using data;
using Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class reclamationController : Controller
    {
        IDatabaseFactory Factory = new DatabaseFactory();
        // GET: Reclamation/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Reclamation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(reclamation r)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reclamation> jbService = new Service<reclamation>(Uok);

            // TODO: Add insert logic here
            jbService.Add(r);
            jbService.Commit();
            return RedirectToAction("Create");
        }

        public ActionResult Index()
        {
            List<reclamation> appo = new List<reclamation>();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reclamation> jbService = new Service<reclamation>(Uok);

            appo = jbService.GetMany().ToList();


            return View(appo);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reclamation> jbService = new Service<reclamation>(Uok);
            reclamation app = jbService.GetById(id);
            if (app == null)
                return View("NotFound");
            else return View(app);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reclamation> jbService = new Service<reclamation>(Uok);
            if (ModelState.IsValid)
            {
                jbService.Delete(jbService.GetById(id));
                jbService.Commit();
                jbService.Dispose();

                

            }
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reclamation> jbService = new Service<reclamation>(Uok);
           reclamation app = jbService.GetById(id);
       

            return View(app);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                IUnitOfWork Uok = new UnitOfWork(Factory);
                IService<reclamation> jbService = new Service<reclamation>(Uok);
             reclamation app = jbService.GetById(id);
                // TODO: Add update logic here
                app.descriptif = Request.Form["descriptif"]; ;

                jbService.Commit();
                return RedirectToAction("Index", new { id = app.idreclamation });
            }
            catch
            {
                return View();
            }
        }


    }
}

