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
    public class ScrumBoardController : Controller
    {
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("api/tickets").Result;
            if (responce.IsSuccessStatusCode) 
            {
                ViewBag.result = responce.Content.ReadAsAsync<IEnumerable<ticket>>().Result;
            } 
            else
            {
                ViewBag.result = "erruer";
            }
            return View();
        }
        
        public ActionResult afficterTicket(int ticketId)
        {

            int test = ticketId;
            //HttpClient Client = new HttpClient();
            //Client.BaseAddress = new Uri("");
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            //var result = Client.PutAsJsonAsync<ticketModel>("api/tickets/employe-ticket-affect" + ticketId,null).Result;

          return RedirectToAction("Index");
        }






        // GET: ScrumBoard/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ScrumBoard/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScrumBoard/Create
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

        // GET: ScrumBoard/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ScrumBoard/Edit/5
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

        // GET: ScrumBoard/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ScrumBoard/Delete/5
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
