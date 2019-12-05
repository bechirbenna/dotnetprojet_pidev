using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Pidev.Models;

namespace Pidev.Controllers
{
    public class congesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: conges
        public ActionResult Index()
        {
            return View(db.conge.ToList());
        }

        // GET: conges/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conge conge = db.conge.Find(id);
            if (conge == null)
            {
                return HttpNotFound();
            }
            return View(conge);
        }

        // GET: conges/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: conges/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nbrjrs,startdate,enddate")] conge conge)
        {
            if (ModelState.IsValid)
            {
                db.conge.Add(conge);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(conge);
        }

        // GET: conges/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conge conge = db.conge.Find(id);
            if (conge == null)
            {
                return HttpNotFound();
            }
            return View(conge);
        }

        // POST: conges/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nbrjrs,startdate,enddate")] conge conge)
        {
            if (ModelState.IsValid)
            {
                db.Entry(conge).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(conge);
        }

        // GET: conges/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            conge conge = db.conge.Find(id);
            if (conge == null)
            {
                return HttpNotFound();
            }
            return View(conge);
        }

        // POST: conges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            conge conge = db.conge.Find(id);
            db.conge.Remove(conge);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
