using data;
using Service;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class autoEvaluateEmployeController : Controller
    {
        userService userService = new userService();
        evaluationService evalService = new evaluationService();
        objectiveService objectiveSeervice = new objectiveService();
        notificationService notifService = new notificationService();

        public static objective getObjectiveByID(long id)
        {
            objectiveService objectiveSeervice = new objectiveService();
            return objectiveSeervice.GetById(id);

        }

        // GET: autoEvaluateEmploye
        public ActionResult Index()
        {
            string token = Request.Cookies.Get("token").Value;
            var jwtToken = new JwtSecurityToken(token);
            var subject = jwtToken.Subject;


            user u1 = userService.getUserByEmail(subject);
            var evals = evalService.GetMany().Where(x => x.idEmploye == u1.id && (x.status.Equals("started") || x.status.Equals("autoEvaluated"))).ToList();

            ViewBag.evals = evals;
            ViewBag.user = u1;
            return View();
        }

        public ActionResult evalOne(long idO, long idE)
        {

            evaluation eval = evalService.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "autoEvaluated";
            eval.mark = 1;

            evalService.Update(eval);
            evalService.ComitAsynch();

            user u = userService.GetById(idE);
            objective o = objectiveSeervice.GetById(idO);

            notification notif = new notification();
            notif.Title = "New Auto Evaluation";
            notif.description = u.firstName + " has auto evaluate him self for " + o.category;
            notif.forUserHavingRole = "Employee";
            notif.notifType = "AUTO_EVALUATION_FROM_EMPLOYE";

            notifService.Add(notif);
            notifService.ComitAsynch();

            return RedirectToAction("Index");

        }

        public ActionResult evalTwo(long idO, long idE)
        {
            evaluation eval = evalService.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "autoEvaluated";
            eval.mark = 2;

            evalService.Update(eval);
            evalService.ComitAsynch();

            user u = userService.GetById(idE);
            objective o = objectiveSeervice.GetById(idO);

            notification notif = new notification();
            notif.Title = "New Auto Evaluation";
            notif.description = u.firstName + " has auto evaluate him self for " + o.category;
            notif.forUserHavingRole = "Employee";
            notif.notifType = "AUTO_EVALUATION_FROM_EMPLOYE";

            notifService.Add(notif);
            notifService.ComitAsynch();

            return RedirectToAction("Index");

        }

        public ActionResult evalThree(long idO, long idE)
        {
            evaluation eval = evalService.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "autoEvaluated";
            eval.mark = 3;

            evalService.Update(eval);
            evalService.ComitAsynch();

            user u = userService.GetById(idE);
            objective o = objectiveSeervice.GetById(idO);

            notification notif = new notification();
            notif.Title = "New Auto Evaluation";
            notif.description = u.firstName + " has auto evaluate him self for " + o.category;
            notif.forUserHavingRole = "Employee";
            notif.notifType = "AUTO_EVALUATION_FROM_EMPLOYE";

            notifService.Add(notif);
            notifService.ComitAsynch();

            return RedirectToAction("Index");

        }

        public ActionResult evalFour(long idO, long idE)
        {
            evaluation eval = evalService.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "autoEvaluated";
            eval.mark = 4;

            evalService.Update(eval);
            evalService.ComitAsynch();

            user u = userService.GetById(idE);
            objective o = objectiveSeervice.GetById(idO);

            notification notif = new notification();
            notif.Title = "New Auto Evaluation";
            notif.description = u.firstName + " has auto evaluate him self for " + o.category;
            notif.forUserHavingRole = "Employee";
            notif.notifType = "AUTO_EVALUATION_FROM_EMPLOYE";

            notifService.Add(notif);
            notifService.ComitAsynch();

            return RedirectToAction("Index");

        }

        public ActionResult evalFive(long idO, long idE)
        {
            evaluation eval = evalService.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "autoEvaluated";
            eval.mark = 5;

            evalService.Update(eval);
            evalService.ComitAsynch();

            user u = userService.GetById(idE);
            objective o = objectiveSeervice.GetById(idO);

            notification notif = new notification();
            notif.Title = "New Auto Evaluation";
            notif.description = u.firstName + " has auto evaluate him self for " + o.category;
            notif.forUserHavingRole = "Employee";
            notif.notifType = "AUTO_EVALUATION_FROM_EMPLOYE";

            notifService.Add(notif);
            notifService.ComitAsynch();

            return RedirectToAction("Index");

        }

        // GET: autoEvaluateEmploye/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: autoEvaluateEmploye/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: autoEvaluateEmploye/Create
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

        // GET: autoEvaluateEmploye/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: autoEvaluateEmploye/Edit/5
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

        // GET: autoEvaluateEmploye/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: autoEvaluateEmploye/Delete/5
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
