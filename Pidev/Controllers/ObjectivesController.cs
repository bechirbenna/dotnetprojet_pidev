using data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Pidev.Controllers
{
    public class ObjectivesController : Controller
    {
        // GET: Objectives
        public ActionResult Index()
        {

            HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/objectives").Result;
            if (response.IsSuccessStatusCode)
            {
                //string jsonstring = JsonConvert.SerializeObject(response);
                //var datalist = JsonConvert.DeserializeObject<objective>(jsonstring);
                //ViewBag.result = datalist;

                //Console.WriteLine(datalist.dateBegin);
                //Console.ReadLine();

                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<objective>>().Result;
            }
            else
            {
                ViewBag.result = "error ";
            }
            return View();
        }

        // GET: Objectives/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Objectives/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Objectives/Create
        [HttpPost]
        public ActionResult Create(objectiveModels obj)
        {

            var aa = obj;
            var response = GlobalVariables.Client.PostAsJsonAsync<objectiveModels>("/pidev-web/rest/objectives", obj).Result;
            
            return RedirectToAction("Index");
        }

        // GET: Objectives/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Objectives/Edit/5
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

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.Client.DeleteAsync("/pidev-web/rest/objectives/" + id.ToString()).Result;

            return RedirectToAction("Index");
        }

        // POST: Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            
                return View();
            
        }

        //// POST: Objectives/Delete/5
        //[HttpPost]
        //public ActionResult Delete()
        //{
        //    HttpResponseMessage response = GlobalVariables.Client.DeleteAsync("/pidev-web/rest/objectives/" + id.ToString()).Result;

        //    return RedirectToAction("Index");
        //}
    }
}
