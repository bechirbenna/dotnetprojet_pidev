

using data;
using Pidev.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Pidev.Controllers
{
    public class FormationController : Controller
    {

        private PidevContext db = new PidevContext();
        // GET: Formation
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("rest/Formation").Result;
            if (responce.IsSuccessStatusCode)
            {
                ViewBag.result = responce.Content.ReadAsAsync<IEnumerable<formation>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
        // GET: Formation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Formation/Create
        [HttpPost]
        public ActionResult Create(FormationModel formation)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            var response = client.PostAsJsonAsync<FormationModel>("rest/Formation", formation).Result;
            return RedirectToAction("Index");
        }



        //// GET: Formation/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    FormateurModel form = null;

        //    HttpClient Client = new HttpClient();
        //    Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        //    HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/rest/GestFORM" + id).Result;
        //    if (response.IsSuccessStatusCode)
        //    {
        //        form = response.Content.ReadAsAsync<Models.FormateurModel>().Result;


        //    }

        //    else
        //    {
        //        ViewBag.result = "error";
        //    }



        //    return View(form);
        //}


    }
}
