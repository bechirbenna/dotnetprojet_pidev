using data;
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
    public class MissionController : Controller
    {
        public ActionResult affmission()
        {
            HttpClient Client = new HttpClient();

            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/api/mission").Result;
            if (response.IsSuccessStatusCode)
            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<mission>>().Result;

            }
            else
            {
                ViewBag.result = "error";

            }


            return View();
        }

        [HttpGet]

        public ActionResult ajout()
        {
            return View("ajout");
        }

        [HttpPost]
        public ActionResult ajout(missionModels m)
        {
            HttpClient client = new HttpClient();

            client.PostAsJsonAsync<missionModels>("http://localhost:9080/pidev-web/api/mission/add", m).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode());
            return RedirectToAction("ajout");




        }

        public ActionResult Delete(int idmission)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.DeleteAsync("http://localhost:9080/pidev-web/api/mission/" + idmission.ToString()).Result;

            return RedirectToAction("affmission");
        }
        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int idmission, FormCollection collection)
        {

            return View();

        }
    }
    }
