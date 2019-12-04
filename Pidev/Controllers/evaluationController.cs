using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Service;
using Pidev.Models;
using System.Collections;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace Pidev.Controllers
{
    public class evaluationController : Controller
    {
        evaluationService serviceEval = new evaluationService();
        objectiveService serviceObjective = new objectiveService();
        userService serviceUser = new userService();

        public static IEnumerable<evaluation> getEvals()
        {
            evaluationService serviceEval = new evaluationService();
            IEnumerable<evaluation> evals = serviceEval.GetMany();
            return serviceEval.GetMany();
        }

        // GET: evaluation
        public ActionResult Index()
        {

            IEnumerable<evaluation> evals = serviceEval.GetMany().ToList();
            
            //connection.Close();
            return View(evals);
        }

        // GET: evaluation/Details/5
        public ActionResult Details(int id)
        {

            return View();
        }

        // GET: evaluation/Create
        public ActionResult Create()
        {
            //evaluationModel eval = new evaluationModel();
            //IEnumerable<objective> objectives = new List<objective>();
            //objectives = serviceObjective.GetMany();
            //ViewBag.objectives = objectives;

            //return View();

            evaluationModel eval = new evaluationModel();
            IEnumerable<objective> objectives = new List<objective>();
            objectives = serviceObjective.GetMany().ToList();
            eval.Objectives = objectives.Select(c => new SelectListItem
            {
                Text = c.name,
                Value = c.id.ToString()
            });

            IEnumerable<user> users = new List<user>();
            users = serviceUser.GetMany().ToList();
            eval.Users = users.Select(c => new SelectListItem
            {
                Text = c.firstName,
                Value = c.id.ToString()
            });

            return View(eval);
        }

        // POST: evaluation/Create
        [HttpPost]
        public ActionResult Create(evaluation ev)
        {

            //string n = Request.Form["objectives"];
            //var objective = serviceObjective.GetMany().Where(x => x.name.Equals(n)).First();
            //ev.objective = objective;

            //evaluation eval = new evaluation();
            //eval.idEmploye = 8 ;
            //eval.date = ev.date;
            //eval.description = ev.description;
            //eval.user = serviceUser.GetById(8);
            //eval.idObjective = ev.idObjective;
            //eval.mark = ev.mark;
            //eval.objective = serviceObjective.GetById(ev.idObjective);
            //eval.status = ev.status;

            //ev.idEmploye = 8;

           

            var n = Request.Form["statuss"];
            ev.status = n;
            serviceEval.Add(ev);
            serviceEval.Commit();



            return RedirectToAction("Index");

        }

        // GET: evaluation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: evaluation/Edit/5
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

        // GET: evaluation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: evaluation/Delete/5
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

        public ActionResult evalOne(long idO, long idE)
        {
            evaluation eval = serviceEval.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "claimed";
            eval.mark = 1;

            serviceEval.Update(eval);
            serviceEval.ComitAsynch();

            user u = serviceUser.GetById(idE);
            objective o = serviceObjective.GetById(idO);

            var verifyurl = "/Signup/VerifiyAccount/";
            var link = Request.Url.AbsolutePath.Replace(Request.Url.PathAndQuery, verifyurl);

            var fromEmail = new MailAddress("manager.esprit@gmail.com", "Your Manager");
            var toEmail = new MailAddress(u.email);

            var FromEmailPassword = "98274765";

            string subject = "Information on Your Euto Evaluation";

            string body = "your manager has confirm your evaluation for the objective " +o.category+ " with mark : " +eval.mark;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromEmail.Address, FromEmailPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromEmail, toEmail)
            {
                Subject = subject,
                Body = body,
                IsBodyHtml = true

            }) smtp.Send(message);


            return RedirectToAction("Index");

        }

        public ActionResult evalTwo(long idO, long idE)
        {
            evaluation eval = serviceEval.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "claimed";
            eval.mark = 2;

            serviceEval.Update(eval);
            serviceEval.ComitAsynch();

            user u = serviceUser.GetById(idE);
            objective o = serviceObjective.GetById(idO);


            return RedirectToAction("Index");
        }

        public ActionResult evalThree(long idO, long idE)
        {
            evaluation eval = serviceEval.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "claimed";
            eval.mark = 3;

            serviceEval.Update(eval);
            serviceEval.ComitAsynch();

            user u = serviceUser.GetById(idE);
            objective o = serviceObjective.GetById(idO);


            return RedirectToAction("Index");

        }

        public ActionResult evalFour(long idO, long idE)
        {
            evaluation eval = serviceEval.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "claimed";
            eval.mark = 4;

            serviceEval.Update(eval);
            serviceEval.ComitAsynch();

            user u = serviceUser.GetById(idE);
            objective o = serviceObjective.GetById(idO);


            return RedirectToAction("Index");

        }

        public ActionResult evalFive(long idO, long idE)
        {
            evaluation eval = serviceEval.GetMany().Where(x => x.idEmploye == idE && x.idObjective == idO).First();
            eval.status = "claimed";
            eval.mark = 5;

            serviceEval.Update(eval);
            serviceEval.ComitAsynch();

            user u = serviceUser.GetById(idE);
            objective o = serviceObjective.GetById(idO);


            return RedirectToAction("Index");

        }

        public static string getUserName(long id)
        {
            userService sU= new userService();
            return sU.GetById(id).firstName;
        }

        public static string getObjectiveName(long id)
        {
            objectiveService sO = new objectiveService();
            return sO.GetById(id).name;
        }

    }
}
