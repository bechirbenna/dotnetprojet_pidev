﻿using data;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class CentersController : Controller
    {
        ServiceCentres serviceCentres = new ServiceCentres();
        // GET: Centers
        public ActionResult Index()
        {
            ViewBag.result = serviceCentres.GetMany();
            return View();
        }

        // GET: Centers/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Centers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Centers/Create
        [HttpPost]
        public ActionResult Create(centres centre)
        { try
            {
                // TODO: Add insert logic here
                serviceCentres.Add(centre);
                serviceCentres.Commit();
                return RedirectToAction("Index"); } 
            catch
                {
                    return View();
                }

            }

        // GET: Centers/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }
        //GET : Center/Edit
        [HttpPost]
        public ActionResult Edit(int id, centres centre)
        {
            try
            {
                var c = serviceCentres.GetById(id);
                c.adresse = centre.adresse;
                c.number = centre.number;
                serviceCentres.Update(c);
                serviceCentres.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Centers/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Centers/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, centres centre)
        {
            try
            {
                var c = serviceCentres.GetById(id);
                serviceCentres.Delete(c);
                serviceCentres.Commit();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("");
            }
        }
    }
}
