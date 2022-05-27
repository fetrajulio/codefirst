using entityCodeFirst.Data;
using entityCodeFirst.Models;
using entityCodeFirst.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace entityCodeFirst.Controllers
{
    public class UserController : Controller
    {
       
        protected Person User;
        protected PersonMeth prM;
        protected MySqlMeth MySqlMeth=new MySqlMeth();
        public  UserController(MyDbContext context)
        {
            prM = new PersonMeth(context);
          
        }
        public IActionResult Index()
        {
            
            

            if (HttpContext.Session.GetString("user") is  null)
            {
                return NotFound();
            }
            else
            {
                string str = HttpContext.Session.GetString("user");
                User = JsonConvert.DeserializeObject<Person>(str);
                prM.Connected(User);
            }
          
            ViewBag.user=User;
            ViewBag.amies = MySqlMeth.AmiConect(User.Name);
            return View("IndexUser");
        }

        public IActionResult Deconect()
        {
            string str = HttpContext.Session.GetString("user");
            User = JsonConvert.DeserializeObject<Person>(str);
            prM.Deconect(User);
            HttpContext.Session.Remove("user");
            
            return Redirect("https://localhost:44370/home");
        }
    }
}
