using data;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class objectiveToTeamController : Controller
    {
        objectiveService serviceObjective = new objectiveService();
        UserService serviceUser = new UserService();
        evaluationService serviceEval = new evaluationService();
        teamService serviceTeam = new teamService();

        public static IEnumerable<team> getAllTeams()
        {
            teamService st = new teamService();
            return st.GetMany().ToList();
        }

        public static int nbEmployeinTeam(long id)
        {
            UserService su = new UserService();
            var a = su.GetMany().Where(x => x.team_id.Equals(id)).Count();
            return a;
        }

       public ActionResult teamChoosed(int idT)
        {
            ViewBag.idT = idT;
            return View();
        }

        [Route("/objectiveToTeam/evaluate/{idO?}/{idT?}")]
        public ActionResult evaluate(int idO , int idT)
        {
            string i = Request.Form["idTeam"];
            //int ii = Int32.Parse(i);

            var a = idT;

            IEnumerable<user> users = serviceUser.GetMany().Where(x=>x.team_id == a).ToList();
            var userss = users;
            var obj = serviceObjective.GetById(idO);

            string str = obj.dateEnd.Substring(0, 10);
            var datee = obj.dateEnd;

            DateTime dt2 = DateTime.ParseExact(str, "dd/MM/yyyy", null);


            foreach (var emp in users)
            {
                evaluation e = new evaluation();
                user u = serviceUser.GetById(emp.id);
                objective o = serviceObjective.GetById(idO);
                e.idEmploye = emp.id;
                e.idObjective = idO;
                //e.user = u;
                //e.objective = o;
                //e.idEmploye = u.id;
                //e.idObjective = o.id;
                e.date = dt2;
                e.status = "pending";
                e.description = null;
                e.mark = 0;
                serviceEval.Add(e);
                serviceEval.Commit();
            }

            return RedirectToAction("Index");


        }

        // GET: objectiveToTeam
        public ActionResult Index()
        {
            return View();
        }

        // GET: objectiveToTeam/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: objectiveToTeam/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: objectiveToTeam/Create
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

        // GET: objectiveToTeam/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: objectiveToTeam/Edit/5
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

        // GET: objectiveToTeam/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: objectiveToTeam/Delete/5
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
