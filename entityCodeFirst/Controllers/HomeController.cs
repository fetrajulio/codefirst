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
            HttpContext.Session.SetString("bema", "julio@gmail.com");
            ViewBag.Pers = prM.trier(myData.ToArray());
            return View();
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
