using data;
using Pidev.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class FormateurController : Controller
    {
        private PidevContext db = new PidevContext();
        // GET: Formation
        public ActionResult Index()
        {

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("rest/GestFORM").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<formateur>>().Result;

            }

            else
            {
                ViewBag.result = "error";
            }
            return View(ViewBag.result);
        }

        // GET: Formation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formation/Create
        [HttpPost]
        public ActionResult Create(FormateurModel formateur)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
              var response = client.PostAsJsonAsync<FormateurModel>("rest/GestFORM", formateur).Result;
            return RedirectToAction("Index");
        }



        // GET: Formation/Edit/5
        public ActionResult Edit(int id)
        {
            FormateurModel form = null;

            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/rest/GestFORM" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                form = response.Content.ReadAsAsync<Models.FormateurModel>().Result;
               

            }

            else
            {
                ViewBag.result = "error";
            }



            return View(form);
        }


        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/pidev-web/rest/GestFORM/" + id.ToString()).Result;

            return RedirectToAction("Index");
        }
        // POST: Formateur/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            return View();

        }
    }



}

