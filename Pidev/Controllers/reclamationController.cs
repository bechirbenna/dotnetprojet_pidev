using data;
using Data.Infrastructure;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class reclamationController : Controller
    {
        IDatabaseFactory Factory = new DatabaseFactory();
        // GET: Reclamation/Create
        public ActionResult creatrec()
        {
            return View("creatrec");
        }

        // POST: Reclamation/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult creatrec(reclamation r)
        {
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reclamation> jbService = new Service<reclamation>(Uok);

            // TODO: Add insert logic here
            jbService.Add(r);
            jbService.Commit();
            var senderEmail = new MailAddress("alihachem.tahar@esprit.tn", "ADMIN");
            var receiverEmail = new MailAddress("alihachem.tahar@esprit.tn", "ADMIN");

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(senderEmail.Address, "hachem1234")
            };
            using (var mess = new MailMessage(senderEmail, receiverEmail)
            {
                Subject = "Traitement des reclamaions",
                Body = "Vous avez une nouvelle reclamation à traiter " 
            })
            {
                smtp.Send(mess);
            }

            return RedirectToAction("creatrec");
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

        public ActionResult Dashbord()
        {

            List<reclamation> appo = new List<reclamation>();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<reclamation> jbService = new Service<reclamation>(Uok);

            appo = jbService.GetMany().ToList();
            List<int> repart = new List<int>();
            var types = appo.Select(x => x.type.Distinct());
            foreach (var item in types)
            {


                // offers = offers.Where(s => s.OfferName.Contains(ratingoffer(0))
                // && s.StartDate == date1);
                repart.Add(appo.Count(x => x.type == item));
            }
                var rep = repart;
                ViewBag.TYPES = types;
                ViewBag.REP = repart.ToList();
            return View();



        }


           

        }


    }

