using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using data;
using System.Web.Script.Serialization;
using Pidev.Models;

namespace Pidev.Controllers
{
    public class TicketController : Controller
    {
        // GET: Ticket
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("api/tickets").Result;
            if(responce.IsSuccessStatusCode)
            {
                ViewBag.result = responce.Content.ReadAsAsync<IEnumerable<ticket>>().Result;
            }else
            {
                ViewBag.result = "erruer";
            }
            return View();
        }

        // GET: Ticket/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Ticket/Create
        public ActionResult Create()
        {

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            HttpResponseMessage responce = client.GetAsync("api/teams").Result;
            

            //if (responce.IsSuccessStatusCode)
            //{
            //    var result = responce.Content.ReadAsAsync<IEnumerable<team>>().Result;
            //    ViewBag.PDVMobileId = new SelectList(result.ToList(), "id", "teamName");
            //}
            //else
            //{
            //    ViewBag.result = "erruer";
            //}
           


            
            return View();
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(ticket ticket)
        {

            string n = String.Format("{0}", Request.Form["estimatedHour"]);
            ticket.estimatedHours = double.Parse(n, System.Globalization.CultureInfo.InvariantCulture);

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            // TODO: Add insert logic here
            client.PostAsJsonAsync<ticket>("api/tickets/"+ticket.team_id, ticket).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()); 
                return RedirectToAction("Index");
            
           
        }

        // GET: Ticket/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Ticket/Edit/5
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

        // GET: Ticket/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Ticket/Delete/5
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
