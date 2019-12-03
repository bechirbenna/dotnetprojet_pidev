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

            TempData["SuccessMessage"] = "Saved Successfully";
            return RedirectToAction("Index");
        }

        // GET: Objectives/Edit/5
        public ActionResult Edit(int id=0)
        {
           if(id ==0)
            {
                return View(new objective());
            }
           else
            {
                HttpResponseMessage response = GlobalVariables.Client.GetAsync("/pidev-web/rest/objectives/" + id.ToString()).Result;
                return View(response.Content.ReadAsAsync<objective>().Result);
            }
        }

        // POST: Objectives/Edit/5
        [HttpPost]
        public ActionResult Edit(objective obj)
        {
            if (obj.id==0)
            {
                var response = GlobalVariables.Client.PostAsJsonAsync<objective>("/pidev-web/rest/objectives", obj).Result;
            }
            else
            {
                var response1 = GlobalVariables.Client.PutAsJsonAsync<objective>("/pidev-web/rest/objectives" , obj).Result;

            }
            return RedirectToAction("index");
        }

        // GET: Project/Delete/5
        public ActionResult Delete(int id)
        {
            HttpResponseMessage response = GlobalVariables.Client.DeleteAsync("/pidev-web/rest/objectives/" + id.ToString()).Result;
            TempData["SuccessMessage"] = "Deleted Successfully";

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
