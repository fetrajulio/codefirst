using entityCodeFirst.Data;
using entityCodeFirst.Models;
using entityCodeFirst.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace entityCodeFirst.Controllers
{
    public class HomeController : Controller
    {
        const string SessionEmail = "_email";
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;
        protected PersonMeth prM;
        public string tete = "";
        public HomeController(ILogger<HomeController> logger,MyDbContext context)
        {
            _logger = logger;
            _context = context;
             prM = new PersonMeth(context);
        }

        public IActionResult Index()
        {
            tete = "Login";
            List<Person> myData = _context.Persons.ToList();
            ViewBag.Persons = myData;
            
            ViewBag.Pers = prM.trier(myData.ToArray());
            return View();
        }
        public IActionResult Login()
        {
            string Email = Request.Form["email"];
            string Mdp = Request.Form["mdp"];

            if (prM.Auth(Email, Mdp) is null)
            {
                return Redirect("Login");
            }
            else
                ViewBag.email = "misy";
            HttpContext.Session.SetString("user", "julio@gmail.com");
            return View("privacy");
        }
        public IActionResult Privacy()
        {
            tete = "Prive";
            ViewBag.email=HttpContext.Session.GetString("bema");
            return View();
        }
        public IActionResult Insc()
        {
            tete = "inscription";
            return View();
        }
        public IActionResult ValideInscription()
        {
            string email= Request.Form["email"];
            string mdp= Request.Form["mdp"];
            string name = Request.Form["nom"];
            int age = int.Parse(Request.Form["age"]);
            int idClasse = int.Parse(Request.Form["classe"]);

            prM.Ajout(new Person(name,age,email,mdp,idClasse));
            return Redirect("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
