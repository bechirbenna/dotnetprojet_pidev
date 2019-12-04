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
        // POST: Skill/Create
        [HttpGet]
        public ActionResult Create()
        {
            return View("Create");
        }
        [HttpPost]
        public ActionResult Create(SkillModel skill)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            //client.PostAsJsonAsync<skill>("api/skill", skill).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            var response = client.PostAsJsonAsync<SkillModel>("api/skill",skill).Result;
            return RedirectToAction("Index");
        }
        // POST: Skill/Update
        public ActionResult Edit(int id)
        {
            //HttpClient Client = new HttpClient();
            //Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/api/skill/"+id.ToString()).Result;
            //SkillModel s = response.Content.ReadAsAsync<SkillModel>().Result;
            //return View(s);
            //Client.DefaultRequestHeaders.Clear();
            //Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/api/skill/" + id.ToString()).Result;
            //return View(response.Content.ReadAsAsync<SkillModel>().Result);

            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id, SkillModel skill)
        {
            HttpClient Client = new HttpClient();
            skill.skillId = id;
            var response1 = Client.PutAsJsonAsync<SkillModel>("http://localhost:9080/pidev-web/api/skill/", skill).Result;
            return RedirectToAction("index");
            //HttpClient client = new HttpClient();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = client.PutAsJsonAsync("http://localhost:9080/pidev-web/api/skill/", skill).Result;
            //return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/pidev-web/api/skill/" + id.ToString()).Result;

            return RedirectToAction("Index");
        }
        // POST: Skill/Delete
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {

            return View();

        }
    }

}