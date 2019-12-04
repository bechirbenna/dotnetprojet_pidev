using data;
using Service;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class objectiveToAllEmployesController : Controller
    {

        objectiveService serviceObjective = new objectiveService();
        userService serviceUser = new userService();
        evaluationService serviceEval = new evaluationService();
        notificationService notifService = new notificationService();

        public static IEnumerable<objective> getObjectives()
        {
            HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/objectives").Result;
            var result = response.Content.ReadAsAsync<IEnumerable<objective>>().Result;
            return result;
           
        }

        
        public ActionResult evaluate(int id)
        {
            IEnumerable<user> users = serviceUser.GetMany().ToList();
            var obj = serviceObjective.GetById(id);
            
            string str = obj.dateEnd.Substring(0, 10);
            var datee = obj.dateEnd;

            DateTime dt2 = DateTime.ParseExact(str, "dd/MM/yyyy", null);

            foreach ( var emp in users)
            { 
                evaluation e = new evaluation();
                user u = serviceUser.GetById(emp.id);
                objective o = serviceObjective.GetById(id);
                e.idEmploye = emp.id;
                e.idObjective = id;
                //e.user = u;
                //e.objective = o;
                //e.idEmploye = u.id;
                //e.idObjective = o.id;
                e.date = dt2 ;
                e.status = "pending";
                e.description = null;
                e.mark = 0 ;
                serviceEval.Add(e);
                serviceEval.ComitAsynch();
            }

            


            return RedirectToAction("Index");


        }

        public ActionResult startEvaluations()
        {
            IEnumerable<evaluation> evaluations = serviceEval.GetMany().Where(x => x.status.Equals("pending")).ToList();
            foreach (var ev in evaluations)
            {
                evaluation e = ev;
                e.status = "started";
              
                serviceEval.Update(e);
                serviceEval.ComitAsynch();
            }

            notification notif = new notification();
            notif.Title = "New Evaluation";
            notif.description = "Evaluation has started ";
            notif.forUserHavingRole = "Employee";
            notif.notifType = "CREATED_EVALUATION_FROM_MANAGER";

            notifService.Add(notif);
            notifService.ComitAsynch();



            return RedirectToAction("adminEval", "objectiveToAllEmployes", new { area = "" });
        }

        public ActionResult adminEval()
        {
            return View();
        }


        // GET: objectiveToAllEmployes
        public ActionResult Index()
        {
            
            return View();
        }

        // GET: objectiveToAllEmployes/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: objectiveToAllEmployes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: objectiveToAllEmployes/Create
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

        // GET: objectiveToAllEmployes/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: objectiveToAllEmployes/Edit/5
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

        // GET: objectiveToAllEmployes/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: objectiveToAllEmployes/Delete/5
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

        public static string getNbTeams()
        {
            HttpResponseMessage response = GlobalVariables.Client.GetAsync("pidev-web/rest/employees/numberTeams").Result;

            var a = response.Content.ReadAsStringAsync().Result;

            return a;
        }

        public static int getNbEmployes()
        {
            userService sU = new userService();
            var a = sU.GetMany().ToList().Count();
            return a;
        }

        public static int getNbPendings()
        {
            evaluationService sE = new evaluationService();
            var a = sE.GetMany().Where(x => x.status.Equals("pending")).ToList().Count();
            return a;
        }
    }
}
