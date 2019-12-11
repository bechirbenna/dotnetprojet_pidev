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
        public ServiceTicket ticketService = new ServiceTicket();
        static UserService userService = new UserService();

        public static int nbr(int id)
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
            return (nbr + 1);
        }
        public static int numberEmployeByTeam(int id)
        {
            return getNameEmployeByTeam(id).Count;
        }

        public  String Month(String mounth)
        {
            //String mounth = System.Web.HttpContext.Current.Request["mounth"];
            return mounth;
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

            List<String> mounths = new List<string>();
            mounths.Add("January");
            mounths.Add("February");
            mounths.Add("March");
            mounths.Add("April");
            mounths.Add("May");
            mounths.Add("June");
            mounths.Add("July");
            mounths.Add("August");
            mounths.Add("September");
            mounths.Add("October");
            mounths.Add("November");
            mounths.Add("December");

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
                ViewBag.mounth = mounths;
            }
            return View();
        }

        /////////////////////////////ticket Report
        public static double getNumberOfTicketHoursInFirstWeek(long id)
        {

           
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfFirstWeek =
                              ticket.Where(n =>
                              (DateTime.Now - n.dateEnd.Value).TotalDays < 7)
                              .Select(x => x.duration).Average();
                var EstimatedHoursFirstWeek =
                             ticket.Where(n =>
                             (DateTime.Now - n.dateEnd.Value).TotalDays < 7)
                             .Select(x => x.estimatedHours).Average();
                return (EstimatedHoursFirstWeek/numberOfFirstWeek)*100;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }

        }
        public static double getAvrageofTicketDurationByEmploye(long id)
        {
            
            try
            {
                var avrage = (getNumberOfTicketHoursInFirstWeek(id)
                              + getNumberOfTicketHoursInSecondWeek(id)
                              + getNumberOfTicketHoursInThirdWeek(id)
                              + getNumberOfTicketHoursInFourthWeek(id)) / 400;
                return avrage;
            }
             catch (InvalidOperationException e)
            {
                return 0;
            }
           
        }
        public static double getNumberOfTicketHoursInSecondWeek(long id)
        {
         
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfSecondtWeek =
                              ticket.Where(n =>(
                              ((DateTime.Now - n.dateEnd.Value).TotalDays > 7)
                              && 
                              (DateTime.Now - n.dateEnd.Value).TotalDays < 14))    
                              .Select(x => x.duration).Average();
                var EstimatedHoursSecondWeek =
                         ticket.Where(n =>
                         (DateTime.Now - n.dateEnd.Value).TotalDays < 7)
                         .Select(x => x.estimatedHours).Average();
                return (EstimatedHoursSecondWeek / numberOfSecondtWeek) * 100;





            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
        }
        public static double getNumberOfTicketHoursInThirdWeek(long id)
        {
           
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfthirdWeek =
                              ticket.Where(n => (
                              ((DateTime.Now - n.dateEnd.Value).TotalDays > 14)
                              &&
                              (DateTime.Now - n.dateEnd.Value).TotalDays < 21))
                              .Select(x => x.duration).Average();
                var EstimatedHoursThirdWeek =
                        ticket.Where(n =>
                        (DateTime.Now - n.dateEnd.Value).TotalDays < 7)
                        .Select(x => x.estimatedHours).Average();
                return (EstimatedHoursThirdWeek / numberOfthirdWeek) * 100;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }

        }
        public static double getNumberOfTicketHoursInFourthWeek(long id)
        {
         
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfthirdWeek =
                              ticket.Where(n => (
                              ((DateTime.Now - n.dateEnd.Value).TotalDays > 21)
                              &&
                              (DateTime.Now - n.dateEnd.Value).TotalDays < 28))
                              .Select(x => x.duration).Average();
                var EstimatedHoursFourthWeek =
                       ticket.Where(n =>
                       (DateTime.Now - n.dateEnd.Value).TotalDays < 7)
                       .Select(x => x.estimatedHours).Average();
                return (EstimatedHoursFourthWeek / numberOfthirdWeek) * 100;
            }
            catch (InvalidOperationException e)
            {
                return 0;
            }
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
