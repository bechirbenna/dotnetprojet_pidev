using data;
using Data.Infrastructure;
using Pidev.Models;
using ServicePattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class PartenaireController : Controller
    {

        IDatabaseFactory Factory = new DatabaseFactory();
        [HttpGet]

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(data.partenariat p)
        {
            HttpClient client = new HttpClient();

            client.PostAsJsonAsync<data.partenariat>("http://localhost:9080/pidev-web/api/partenaire/add", p).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Create");




        }

        public ActionResult affpart()
        {
            HttpClient Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/api/partenaire").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<data.partenariat>>().Result;

            }
            else
            {
                ViewBag.result = "error";

            }


            return View();
        }

        public  ActionResult Delete(int idpartenaire)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/pidev-web/api/partenaire/" + idpartenaire.ToString()).Result;

            return RedirectToAction("affpart");
        }
        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int idpartenaire, FormCollection collection)
        {

            return View();

        }

        public ActionResult Dashbord()
        {

            List<data.partenariat> appo = new List<data.partenariat>();
            IUnitOfWork Uok = new UnitOfWork(Factory);
            IService<data.partenariat> jbService = new Service<data.partenariat>(Uok);
           

            appo = jbService.GetMany().ToList();
            List<int> repart = new List<int>();
            var nbres = appo.Select(x => x.nbreop);
            var nom = appo.Select(x => x.nompartenaire);




            ViewBag.NBRES = nbres;
            ViewBag.REP = nom;
            return View();



        }

        // GET: Objectives/Edit/5
        public ActionResult Edit(int idpartenaire = 0)
        {

            HttpClient client = new HttpClient();
            if (idpartenaire == 0)
            {
                return View(new data.partenariat());
            }
            else
            {
                HttpResponseMessage response = client.GetAsync("http://localhost:9080/pidev-web/api/partenaire/" + idpartenaire.ToString()).Result;
                return View(response.Content.ReadAsAsync<data.partenariat>().Result);
            }
        }

        // POST: Objectives/Edit/5
        [HttpPost]
        public ActionResult Edit(data.partenariat p)
        {
            HttpClient client = new HttpClient();
            if (p.idpartenaire == 0)
            {
                var response = client.PostAsJsonAsync<data.partenariat>("http://localhost:9080/pidev-web/api/partenaire/", p).Result;
            }
            else
            {
                var response1 = client.PutAsJsonAsync<data.partenariat>("http://localhost:9080/pidev-web/api/partenaire/", p).Result;

            }
            return RedirectToAction("affpart");
        }

    }
}