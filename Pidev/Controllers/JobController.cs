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
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage responce = Client.GetAsync("api/job").Result;
            if (responce.IsSuccessStatusCode)
            {
                ViewBag.result = responce.Content.ReadAsAsync<IEnumerable<JobModel>>().Result;
            }
            else
            {
                ViewBag.result = "error";
            }
            return View();
        }

        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(JobModel job)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
            //client.PostAsJsonAsync<skill>("api/skill", skill).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            var response = client.PostAsJsonAsync<JobModel>("api/job", job).Result;
            return RedirectToAction("Index");
        }

        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, JobModel job)
        {
            HttpClient Client = new HttpClient();
            job.jobId = id;
            var response1 = Client.PutAsJsonAsync<JobModel>("http://localhost:9080/pidev-web/api/job/", job).Result;
            return RedirectToAction("index");
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/pidev-web/api/job/" + id.ToString()).Result;

            return RedirectToAction("Index");
        }

        // POST: Job/Delete/5
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
