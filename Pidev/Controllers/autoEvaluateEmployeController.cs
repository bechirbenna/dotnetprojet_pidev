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

        public ActionResult statEvalObj()
        {
            var evals = evalService.GetMany().Where(x => x.status.Equals("autoEvaluated")).ToList();
            var users = new List<user>();

            foreach (var eval in evals)
            {
                if  (!users.Contains(eval.user))
                users.Add(eval.user);
            }

            ViewBag.users = users;

            return View();
        }

        public static int pourcentageObj(long id)
        {
            evaluationService evalService = new evaluationService();
            var evals = evalService.GetMany().Where(x => x.idEmploye == id && x.status.Equals("autoEvaluated")).ToList();
            int a = 0;
            foreach(var e in evals)
            {
                a = a + (int)e.mark;
            }

            int p = (a * 100) / (evals.Count() * 5);

            int pourc = 0; 
            if (p >= 1 && p <= 4)
            {
                pourc = 0;
            }
            else if (p >= 5 && p <= 9)
            {
                pourc = 5;
            }
            else if (p >= 10 && p <= 14)
            {
                pourc = 10;
            }
            else if (p >= 15 && p <= 19)
            {
                pourc = 15;
            }
            else if (p >= 20 && p <= 24)
            {
                pourc = 20;
            }
            else if (p >= 25 && p <= 29)
            {
                pourc = 25;
            }
            else if (p >= 30 && p <= 34)
            {
                pourc = 30;
            }
            else if (p >= 35 && p <= 39)
            {
                pourc = 35;
            }
            else if (p >= 40 && p <= 44)
            {
                pourc = 40;
            }
            else if (p >= 45 && p <= 49)
            {
                pourc = 45;
            }
            else if (p >= 50 && p <= 54)
            {
                pourc = 50;
            }
            else if (p >= 55 && p <= 59)
            {
                pourc = 55;
            }
            else if (p >= 60 && p <= 64)
            {
                pourc = 60;
            }
            else if (p >= 65 && p <= 69)
            {
                pourc = 65;
            }
            else if (p >= 70 && p <= 74)
            {
                pourc = 70;
            }
            else if (p >= 75 && p <= 79)
            {
                pourc = 75;
            }
            else if (p >= 80 && p <= 84)
            {
                pourc = 80; 
            }
            else if (p >= 85 && p <= 89)
            {
                pourc = 85;
            }
            else if (p >= 90 && p <= 94)
            {
                pourc = 90;
            }
            else if (p >= 95 && p <= 99)
            {
                pourc = 95;
            }
            else if (p == 100)
            {
                pourc = 100;
            }

            return pourc;
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
