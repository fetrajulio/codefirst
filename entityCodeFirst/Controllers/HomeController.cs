using entityCodeFirst.Data;
using entityCodeFirst.Models;
using entityCodeFirst.Repo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
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
            if (HttpContext.Session.GetString("user") is not null)
            {
                return NotFound();
            }
            tete = "Login";
            
            return View();
        }
        public IActionResult Login()
        {
           
            string Email = Request.Form["email"];
            string Mdp = Request.Form["mdp"];

            if (prM.Auth(Email, Mdp) is null)
            {
                return Redirect("Index");
            }
            Person user = prM.Auth(Email, Mdp);
            HttpContext.Session.SetString("email", Email);
            HttpContext.Session.SetString("mdp", Mdp);
            var objet = JsonConvert.SerializeObject(user);
            HttpContext.Session.SetString("user", objet);
            return Redirect("https://localhost:44370/user");
        }
        public IActionResult Privacy()
        {
            tete = "Prive";
            ViewBag.email=HttpContext.Session.GetString("bema");
            return View();
        }
        public IActionResult Insc()
        {
            if (HttpContext.Session.GetString("user") is not null)
            {
                return NotFound();
            }
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
