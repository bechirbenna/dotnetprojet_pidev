using data;
using Pidev.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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


            string token = Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
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
        
        public  ActionResult afficterTicket(int idTicket)
        {

            string token = Request.Cookies.Get("token").Value;
            int test = idTicket;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var jwtToken = new JwtSecurityToken(token);
            var subject = jwtToken.Subject;

            HttpResponseMessage responce = Client.GetAsync("api/login/" + subject).Result;
            if (responce.IsSuccessStatusCode)
            {
                userModel user = responce.Content.ReadAsAsync<userModel>().Result;
            
                var result = Client.PutAsJsonAsync<ticketModel>("api/tickets/employe-ticket-affect/" + idTicket+"/"+ user.id, null).Result;
            }
            return RedirectToAction("Index"); 
        }

        public ActionResult DoIt(int idTicket)
        {

            string token = Request.Cookies.Get("token").Value;
            int test = idTicket;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var jwtToken = new JwtSecurityToken(token);
            var subject = jwtToken.Subject;

            HttpResponseMessage responce = Client.GetAsync("api/login/" + subject).Result;
            if (responce.IsSuccessStatusCode)
            {
                userModel user = responce.Content.ReadAsAsync<userModel>().Result;
                var result = Client.PutAsJsonAsync<ticketModel>("api/tickets/employe-ticket-begin/" + idTicket + "/" + user.id, null).Result;
            }
            return RedirectToAction("Index");
        }


        public ActionResult finishIt(int idTicket)
        {

            string token = Request.Cookies.Get("token").Value;
            int test = idTicket;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var jwtToken = new JwtSecurityToken(token);
            var subject = jwtToken.Subject;

            HttpResponseMessage responce = Client.GetAsync("api/login/" + subject).Result;
            if (responce.IsSuccessStatusCode)
            {
                userModel user = responce.Content.ReadAsAsync<userModel>().Result;
                var result = Client.PutAsJsonAsync<ticketModel>("api/tickets/employe-ticket-end/" + idTicket + "/"+user.id, null).Result;
            }
            return RedirectToAction("Index");
        }

        public ActionResult archiveIt(int idTicket)
        {

            string token = Request.Cookies.Get("token").Value;
            int test = idTicket;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var jwtToken = new JwtSecurityToken(token);
            var subject = jwtToken.Subject;

            HttpResponseMessage responce = Client.GetAsync("api/login/" + subject).Result;
            if (responce.IsSuccessStatusCode)
            {
                userModel user = responce.Content.ReadAsAsync<userModel>().Result;
                var result = Client.PutAsJsonAsync<ticketModel>("api/tickets/employe-ticket-archive/" + idTicket + "/"+user.id, null).Result;
            }
            return RedirectToAction("Index");
        }






        public  string storeToken()
        {
            return Request.Cookies.Get("token").Value;
        }


        public   Boolean disabled(int id)
        {
           
            string token = Request.Cookies.Get("token").Value;

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/ticket-validator"+id).Result;
            if (responce.StatusCode.Equals(System.Net.HttpStatusCode.Accepted))
                {
                return true;
                }else 
            return false;
        }

        public static int ticketColor(int id)
        {

            ScrumBoardController scr = new ScrumBoardController();
            string token = scr.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/ticket-color/" + id).Result;
            if (responce.ReasonPhrase.Equals("Ticket  en avance"))
            {
                return 1;
            }
            else if (responce.ReasonPhrase.Equals("Ticket ni en avance ni en retard"))
                return 2;
            else
            {
                return 3;
            }
        }


        public static double compareDate(int id)
        {

            ScrumBoardController scr = new ScrumBoardController();
            string token = scr.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("api/tickets/ticket-achievement/" + id).Result;
            if (responce.IsSuccessStatusCode)
            {
                String number = responce.Content.ReadAsStringAsync().Result;
                return double.Parse(number);
            }
            return 0.0;

        }


        public static double compareDate1(int id)
        {

            ScrumBoardController scr = new ScrumBoardController();
            string token = scr.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/ticket-achievement-second-part/" + id).Result;
            if (responce.IsSuccessStatusCode)
            {
                String number = responce.Content.ReadAsStringAsync().Result;
                return double.Parse(number);
            }
            return 0.0;

        }

        public static double compareDate2(int id)
        {

            ScrumBoardController scr = new ScrumBoardController();
            string token = scr.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/ticket-achievement-third-part/" + id).Result;
            if (responce.IsSuccessStatusCode)
            {
                String number = responce.Content.ReadAsStringAsync().Result;
                return double.Parse(number);
            }
            return 0.0;

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
