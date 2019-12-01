using data;
using Pidev.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class ReportController : Controller
    {

        static UserService userService = new UserService();
     
        public   static int nbr(int id)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
         
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");

            int nbr;
            HttpResponseMessage responceUsers = Client.GetAsync("api/login").Result;
            if (responceUsers.IsSuccessStatusCode)
            {
                var users = responceUsers.Content.ReadAsAsync<IEnumerable<userModel>>().Result;
                nbr = users.Where(user => user.team.id.Equals(id)).Count();
            }
            else { nbr = 0; }
            return (nbr+1);
        }
        public static int numberEmployeByTeam(int id)
        {
            return getNameEmployeByTeam(id).Count;
        }

        public static List<String> getNameEmployeByTeam(int id)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            HttpResponseMessage response = Client.GetAsync("api/teams/team-ticket-name/" + id).Result;
            var stringList = response.Content.ReadAsAsync<List<String>>().Result;
            return stringList;
        }

        public static List<userModel> getEmployeesByTeamID(int id)
        {
            HttpClient Client = new HttpClient();
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");


            HttpResponseMessage responceUsers = Client.GetAsync("api/login").Result;

            if (responceUsers.IsSuccessStatusCode)
            {
                var users = responceUsers.Content.ReadAsAsync<IEnumerable<userModel>>().Result;
                return users.Where(user => user.team.id == id).ToList();
            }
            else return null;
        }



        // GET: Report
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

            HttpResponseMessage responceTicket = Client.GetAsync("api/tickets").Result;
            HttpResponseMessage responceTeam = Client.GetAsync("api/teams").Result;
            HttpResponseMessage responceUsers = Client.GetAsync("api/login").Result;
            if (responceTicket.IsSuccessStatusCode && responceTeam.IsSuccessStatusCode && responceUsers.IsSuccessStatusCode)
            {
                ViewBag.tickets = responceTicket.Content.ReadAsAsync<IEnumerable<ticketModel>>().Result;
                var teams = responceTeam.Content.ReadAsAsync<IEnumerable<TeamModel>>().Result;
                ViewBag.teams = teams;
                ViewBag.teamNumber = teams.Count();
                ViewBag.users = responceUsers.Content.ReadAsAsync<IEnumerable<userModel>>().Result;
            }
            return View();
        }

        /////////////////////////////ticket Report
        public static int getNumberOfTicketHoursInFirstWeek(int id)
        {
            return 2;
        }
        public static int getNumberOfTicketHoursInSecondWeek(int id)
        {
            return 2;
        }
        public static int getNumberOfTicketHoursInThirdWeek(int id)
        {
            return 2;
        }
        public static int getNumberOfTicketHoursInFourthWeek(int id)
        {
            return 2;
        }



        /////////////////////////////End ticket Report


        // GET: Report/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Report/Create
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

        // GET: Report/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Report/Edit/5
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

        // GET: Report/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Report/Delete/5
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
