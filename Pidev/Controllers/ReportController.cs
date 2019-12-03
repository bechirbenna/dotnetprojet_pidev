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

        public String Month(String mounth)
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
        public static double getNumberOfRealizedTicketHoursInFirstWeek(long id)
        {
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (30 - DateTime.Now.Day);
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfFirstWeek =
                              ticket.Where(n =>
                              (30 - n.dateEnd.Value.Day) > 23)
                              .Select(x => x.duration).Average();

                return numberOfFirstWeek;
            }
            catch 
            {
                return 0;
            }

        }

        public static double getNumberOfEstimatedTicketHoursInFirstWeek(long id)
        {
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (30 - DateTime.Now.Day);
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var EstimatedHoursFirstWeek =
                             ticket.Where(n =>
                            (30 - n.dateEnd.Value.Day) > 23)
                             .Select(x => x.estimatedHours).Average();
                return EstimatedHoursFirstWeek ;
            }
            catch 
            {
                return 0;
            }

        }

        public static double getNumberOfTicketHoursInFirstWeek(long id)
        {
            
            try
            {
               return (getNumberOfEstimatedTicketHoursInFirstWeek(id)/ getNumberOfRealizedTicketHoursInFirstWeek(id))*100;
            }
            catch 
            {
                return 0;
            }

        }


        /// <summary>
        /// /////////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>




        public static double getNumberOfTicketHoursEstimatedInSecondWeek(long id)
        {

            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var EstimatedHoursSecondWeek =
                                     ticket.Where(n => (
                              ((30 - n.dateEnd.Value.Day) > 16)
                              &&
                              ((30 - n.dateEnd.Value.Day) < 23)))
                         .Select(x => x.estimatedHours).Average();



                return EstimatedHoursSecondWeek ;

            }
            catch 
            {
                return 0;
            }
        }
        public static double getNumberOfTicketHoursRealizedInSecondWeek(long id)
        {

            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfSecondtWeek =
                              ticket.Where(n => (
                              ((30 - n.dateEnd.Value.Day) > 16)
                              &&
                              ((30 - n.dateEnd.Value.Day) < 23)))
                              .Select(x => x.duration).Average();



                return numberOfSecondtWeek;

            }
            catch 
            {
                return 0;
            }
        }


        public static double getNumberOfTicketHoursInSecondtWeek(long id)
        {

            try
            {
                return (getNumberOfTicketHoursEstimatedInSecondWeek(id) / getNumberOfTicketHoursRealizedInSecondWeek(id)) * 100;
            }
            catch 
            {
                return 0;
            }

        }



        /// <summary>
        /// /////////////////////////////////
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>











        public static double getNumberOfTicketHoursEstimatedInThirdWeek(long id)
        {

            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
        
                var EstimatedHoursThirdWeek =
                        ticket.Where(n =>(
                          ((30 - n.dateEnd.Value.Day) > 9)
                              &&
                              ((30 - n.dateEnd.Value.Day) < 16)))
                        .Select(x => x.estimatedHours).Average();
                return EstimatedHoursThirdWeek  ;
            }
            catch 
            {
                return 0;
            }

        }
        public static double getNumberOfTicketHoursRealizedInThirdWeek(long id)
        {

            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfthirdWeek =
                              ticket.Where(n => (
                                ((30 - n.dateEnd.Value.Day) > 9)
                              &&
                              ((30 - n.dateEnd.Value.Day) < 16)))
                              .Select(x => x.duration).Average();

                return  numberOfthirdWeek;
            }
            catch 
            {
                return 0;
            }

        }

        public static double getNumberOfTicketHoursInThirdtWeek(long id)
        {

            try
            {
                return (getNumberOfTicketHoursEstimatedInThirdWeek(id) / getNumberOfTicketHoursRealizedInThirdWeek(id)) * 100;
            }
            catch 
            {
                return 0;
            }

        }




        /// <summary>
        /// Ticket in Second Weeek
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static double getNumberOfTicketHoursEstimatedInFourthWeek(long id)
        {

            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var EstimatedHoursFourthWeek =
                       ticket.Where(n =>(
                      ((30 - n.dateEnd.Value.Day) > 0)
                              &&
                              ((30 - n.dateEnd.Value.Day) < 9)))
                       .Select(x => x.estimatedHours).Average();
                return EstimatedHoursFourthWeek ;
            }
            catch 
            {
                return 0;
            }
        }
        public static double getNumberOfTicketHoursRealizedInFourthWeek(long id)
        {
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();
            try
            {
                var numberOfthirdWeek =
                              ticket.Where(n => (
                               ((30 - n.dateEnd.Value.Day) > 0)
                              &&
                              ((30 - n.dateEnd.Value.Day) < 9)))
                              .Select(x => x.duration).Average();

                return numberOfthirdWeek;
            }
            catch 
            {
                return 0;
            }
        }


        public static double getNumberOfTicketHoursInFourthtWeek(long id)
        {

            try
            {
                return (getNumberOfTicketHoursEstimatedInFourthWeek(id) / getNumberOfTicketHoursRealizedInFourthWeek(id)) * 100;
            }
            catch 
            {
                return 0;
            }

        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static double getAvrageofTicketDurationByEmploye(long id)
        {
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();

            try
            {
                var EstimatedHoursFirstWeek =
                            ticket
                            .Select(x => x.duration).Sum();
                return EstimatedHoursFirstWeek;
            }
            catch 
            {
                return 0;
            }

        }


        public static double getAvrageofTicketEstimatedHoursByEmploye(long id)
        {
            ServiceTicket serviceTicket = new ServiceTicket();
            var dateNow = (DateTime.Now - DateTime.Now.AddDays(-25)).TotalDays;
            IList<ticket> ticket = serviceTicket.GetMany()
            .Where(t => (t.employesTicket_id == id)).ToList();

            try
            {
                var EstimatedHoursFirstWeek =
                            ticket
                            .Select(x => x.estimatedHours).Sum();
                return EstimatedHoursFirstWeek;
            }
            catch 
            {
                return 0;
            }

        }

        public static double getestimatedDreal(long id)
        {
           

            try
            {
               
                return (getAvrageofTicketEstimatedHoursByEmploye(id)/ getAvrageofTicketDurationByEmploye(id))*100;
            }
            catch 
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
