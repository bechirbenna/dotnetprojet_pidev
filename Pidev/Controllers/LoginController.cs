using Microsoft.Owin.Security;
using Newtonsoft.Json;
using Pidev.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;
namespace Pidev.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login(userModel model, string returnUrl)
        {
            //var getTokenUrl = string.Format(Token, ConfigurationManager.AppSettings["localhost:9080/pidev-web/api/athentication"]);
                 
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    HttpContent content = new FormUrlEncodedContent(new[]  
            //    {
            //        new KeyValuePair<string, string>("username", model.Username),
            //        new KeyValuePair<string, string>("password", model.Password)
            //    });

            //    //HttpResponseMessage result = httpClient.PostAsync(getTokenUrl, content).Result;

            //    string resultContent = result.Content.ReadAsStringAsync().Result;

            //    var token = JsonConvert.DeserializeObject<Token>(resultContent);

            //    AuthenticationProperties options = new AuthenticationProperties();

            //    options.AllowRefresh = true;
            //    options.IsPersistent = true;
            //    options.ExpiresUtc = DateTime.UtcNow.AddSeconds(int.Parse(token.expires_in));

            //    var claims = new[]
            //    {
            //        new Claim(ClaimTypes.Name, model.Username),
            //        new Claim("AcessToken", string.Format("Bearer {0}", token.access_token)),
            //    };

            //    var identity = new ClaimsIdentity(claims, "ApplicationCookie");

            //    Request.GetOwinContext().Authentication.SignIn(options, identity);

            //}

            return RedirectToAction("Index", "Home");
        }
        public ActionResult LogOut()
        {
            Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");

            return RedirectToAction("Login");
        }
        
    }
}
