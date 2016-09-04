using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AdminPanelFabQC.Controllers
{
    public class LoginController : Controller
    {
        //
        // GET: /Login/

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(Models.LoginDetails user)
        {
            if (ModelState.IsValid)
            {
                string url = "http://fabqc.just4u.in/api/User/ULgn";
                HttpClient client;
                client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage responseMessage = await client.PostAsJsonAsync(url,user);
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseData = responseMessage.Content.ReadAsStringAsync().Result;

                    var response = JsonConvert.DeserializeObject<AdminPanelFabQC.Models.LoginRes>(responseData);
                    if (response.status == "true")
                        return View("home",response.userDetail);
                    else
                    {
                        user.showError = "true";
                        return View("login",user);
                    }
                }
                else
                {
                    return View("Error");
                }
                //if (user.IsValid(user.UserName, user.Password))
                //{
                //    FormsAuthentication.SetAuthCookie(user.UserName, user.RememberMe);
                //    return RedirectToAction("Index", "Home");
                //}
                //else
                //{
                //    ModelState.AddModelError("", "Login data is incorrect!");
                //}
            }
            return View(user);
        }
    }
}
