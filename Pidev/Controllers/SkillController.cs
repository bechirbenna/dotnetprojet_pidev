using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Pidev.Models;
using data;
using System.Net.Http;
using System.Net.Http.Headers;

namespace Pidev.Controllers
{
    public class SkillController : Controller
    {
        private PidevContext db = new PidevContext();
        // GET: Skill
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("api/skill").Result;
            if (responce.IsSuccessStatusCode)
            {
                ViewBag.result = responce.Content.ReadAsAsync<IEnumerable<skill>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }
    }
}