using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Pidev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using data;
namespace Pidev.Controllers
{
    public class LoginController : Controller
    {

        public ActionResult Index()
        {

            return View();
        }

        [HttpPost]
        public ActionResult Index(string email, string password)
        {
            HttpCookie cookie = HttpContext.Response.Cookies["token"];
            cookie.Value = GetToken(email, password);
            if (cookie != null)
            {
                Response.Cookies.Add(cookie);
                string token = Request.Cookies.Get("token").Value;


                HttpClient Client = new HttpClient();
                Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //var t = JsonConvert.DeserializeObject<Token>(token);
               
                //Client.DefaultRequestHeaders.Clear();
                //Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
                //Client.DefaultRequestHeaders.Add("Content-Type", "application/json");
                Client.BaseAddress = new Uri("http://localhost:9080/pidev-web/");
                var jwtToken = new JwtSecurityToken(token);
                var subject = jwtToken.Subject;

                HttpResponseMessage responce = Client.GetAsync("api/login/" + subject).Result;
                if (responce.IsSuccessStatusCode)
                {
                    userModel user = responce.Content.ReadAsAsync<userModel>().Result;
                    if (user.role.Equals("Admin"))
                    {
                        return RedirectToAction("Index", "Ticket", new { area = "" });
                    }if (user.role.Equals("Employee"))
                    {
                        return RedirectToAction("Index", "ScrumBoard", new { area = "" });
                    }
                       
                }
               
            }
            return View();

        }


        public ActionResult LogOut()
        {
             Response.Cookies["token"].Expires = DateTime.Now.AddDays(-1);
            return RedirectToAction("Index");
        }




        // GET: Login
        public static string GetToken(string userName, string password)
        {
            var pairs = new List<KeyValuePair<string, string>>
                    {
                        new KeyValuePair<string, string>( "grant_type", "password" ),
                        new KeyValuePair<string, string>( "username", userName ),
                        new KeyValuePair<string, string> ( "password", password )
                    };
            var content = new FormUrlEncodedContent(pairs);
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                string url = "http://localhost:9080/pidev-web/api";
                var response = client.PostAsync(url + "/athentication", content).Result;


                return response.Content.ReadAsStringAsync().Result;
            }
        }

        public static string CallApi(string url, string token)
        {

            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => true;
            using (var client = new HttpClient())
            {
                if (!string.IsNullOrWhiteSpace(token))
                {
                    var t = JsonConvert.DeserializeObject<Token>(token);

                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + t.access_token);
                }
                var response = client.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

    }
}
