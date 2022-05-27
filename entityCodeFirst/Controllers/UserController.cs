using entityCodeFirst.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace entityCodeFirst.Controllers
{
    public class UserController : Controller
    {
        protected Person User; 
        public  UserController()
        {
           

        }
        public IActionResult Index()
        {
            var str = HttpContext.Session.GetString("user");
            

            if (HttpContext.Session.GetString("user") is  null)
            {
                return NotFound();
            }
            else
            {
                User = JsonConvert.DeserializeObject<Person>(str);
            }
          
            ViewBag.user=User;
            return View("IndexUser");
        }

        public IActionResult Deconect()
        {
            HttpContext.Session.Remove("user");
            return Redirect("https://localhost:44370/home");
        }
    }
}
