using data;
using Pidev.Models;
using Service;
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
         
        ServiceCalendar serviceCalendar = new ServiceCalendar(); 
        public ActionResult Index()
        {

            string token = Request.Cookies.Get("token").Value;
          
           
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            var jwtToken = new JwtSecurityToken(token);
            var subject = jwtToken.Subject;

            HttpResponseMessage current = Client.GetAsync("api/login/" + subject).Result;
            if (current.IsSuccessStatusCode)
            {

                ViewBag.current_user = current.Content.ReadAsAsync<userModel>().Result;
            }


            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            HttpResponseMessage responce = Client.GetAsync("api/tickets").Result;
            if (responce.IsSuccessStatusCode) 
            {              
                 List<ticket> tickets = (List<ticket>) responce.Content.ReadAsAsync<IEnumerable<ticket>>().Result;
                var ticketts = tickets.Where(t => t.dateEnd != null && t.dateBegin != null).ToList();
                // var tick = ticketts.Where(ta => ta.dateBegin.Value.Day < Event.Select(x => x.DateDebut.Day) && ta.dateEnd.Value.Day > Event.Select(xa => xa.DateFin.Day));

                //ViewBag.result = ticketts.Where(t => ((notIn(t.dateBegin)) && (notIn(t.dateEnd)) )) ;
                ViewBag.result = tickets;
            } 
            else
            {
                ViewBag.result = "erruer";
            }
            return View();
        }


        //public static Boolean notIn(DateTime? date)
        //{
        //    Boolean boolean;
        //    ServiceCalendar serviceCalendar = new ServiceCalendar();
        //    IEnumerable<calendar> calendars = serviceCalendar.GetMany().ToList();
        //    foreach (calendar c in calendars)
        //    {
        //        boolean = !IsBewteenTwoDates(date, c.DateDebut, c.DateFin);
        //    }

        //    return boolean;
        //}
        public static Boolean IsBewteenTwoDates(DateTime? dt, DateTime start, DateTime end)
        {
            return ((dt >= start) && (dt <= end));
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
                var result = Client.PutAsJsonAsync<ticketModel>("api/tickets/" + idTicket+"/"+ user.id+ "/affecter", null).Result;
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
                var result = Client.PutAsJsonAsync<ticket>("api/tickets/" + idTicket + "/" + user.id+ "/begin", null).Result;
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
                var result = Client.PutAsJsonAsync<ticket>("api/tickets/" + idTicket + "/"+user.id+ "/End", null).Result;
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
                var result = Client.PutAsJsonAsync<ticket>("api/tickets/" + idTicket + "/"+user.id+ "/archive", null).Result;
            }
            return RedirectToAction("Index");
        }






        public  string storeToken()
        {
            return Request.Cookies.Get("token").Value;
        }


        public   static Boolean disabled(int id)
        {

            string token = System.Web.HttpContext.Current.Request.Cookies.Get("token").Value;
             

            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/"+id+ "/validate").Result;
            if (responce.StatusCode.Equals(System.Net.HttpStatusCode.Accepted))
                {
                return true;
                }else 
            return false;
        }

        public static int ticketColor(int id)
        {
            
            string token = System.Web.HttpContext.Current.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/" + id+ "/avancement").Result;
            if (responce.StatusCode == System.Net.HttpStatusCode.OK)
            {
                return 1;
            }
            else if (responce.StatusCode == System.Net.HttpStatusCode.Accepted)
                return 2;
            else
            {
                return 3;
            }
        }


        public static double compareDate(int id)
        {

            string token = System.Web.HttpContext.Current.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("api/tickets/" + id+ "/achievement-part-one").Result;
            if (responce.IsSuccessStatusCode)
            {
                String number = responce.Content.ReadAsStringAsync().Result;
                return double.Parse(number);
            }
            return 0.0;

        }


        public static double compareDate1(int id)
        {

            string token = System.Web.HttpContext.Current.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/" + id+ "/achievement-second-part").Result;
            if (responce.IsSuccessStatusCode)
            {
                String number = responce.Content.ReadAsStringAsync().Result;
                return double.Parse(number);
            }
            return 0.0;

        }

        public static double compareDate2(int id)
        {

            string token = System.Web.HttpContext.Current.Request.Cookies.Get("token").Value;
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.DefaultRequestHeaders.Clear();
            Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);

            HttpResponseMessage responce = Client.GetAsync("api/tickets/" + id+ "/achievement-third-part").Result;
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
