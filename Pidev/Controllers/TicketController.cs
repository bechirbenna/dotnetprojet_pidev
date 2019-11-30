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
using Service;
using Newtonsoft.Json;

namespace Pidev.Controllers
{
    public class TicketController : Controller
    {

        private PidevContext db = new PidevContext();
        // GET: Ticket
        public ActionResult Index()
        {

            //HttpCookieCollection result = Request.Cookies;
            string token = Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var t = JsonConvert.DeserializeObject<Token>(token);
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            //Client.DefaultRequestHeaders.Add("Content-Type", "application/json");
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
           
            HttpResponseMessage responce = Client.GetAsync("api/tickets").Result;

            
            if (responce.IsSuccessStatusCode)
            {
                ViewBag.result = responce.Content.ReadAsAsync<IEnumerable<ticket>>().Result;
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
            string token = Request.Cookies.Get("token").Value;
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            HttpResponseMessage responce = client.GetAsync("api/teams").Result;

            ticketModel ticketModel = new ticketModel();


            if (responce.IsSuccessStatusCode)
            {
                
                ViewBag.teams = responce.Content.ReadAsAsync<IList<team>>().Result;
             
            }
            else
            {
                ViewBag.result = "erruer";
            }




            return View(ticketModel);
        }

        // POST: Ticket/Create
        [HttpPost]
        public ActionResult Create(ticketModel ticket,double estimatedHour)
        {
            string token = Request.Cookies.Get("token").Value;
            string n =Request.Form["teamName"];
            string diff = Request.Form["difficulity"];
             HttpClient client = new HttpClient();
            ticket.estimatedHours = estimatedHour;
            ticket.difficulty = diff;
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");

            HttpResponseMessage responce = client.GetAsync("api/teams/"+n).Result;

            if (responce.IsSuccessStatusCode)
            {
                ticket.team = responce.Content.ReadAsAsync<TeamModel>().Result;
            }
            // ticket.team = responce.


            // ticket.team = responce;

            // TODO: Add insert logic here

            var result = client.PostAsJsonAsync<ticketModel>("api/tickets", ticket).Result;
            
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
