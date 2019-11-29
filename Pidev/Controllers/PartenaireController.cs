using data;
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
        [HttpGet]

        public ActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public ActionResult Create(partenariat p)
        {
            HttpClient client = new HttpClient();

            client.PostAsJsonAsync<partenariat>("http://localhost:9080/pidev-web/api/partenaire/add", p).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("Create");




        }

        public ActionResult affpart()
        {
            HttpClient Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/api/partenaire").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<partenariat>>().Result;

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
    }
}