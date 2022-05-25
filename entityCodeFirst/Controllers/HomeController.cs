using entityCodeFirst.Data;
using entityCodeFirst.Models;
using entityCodeFirst.Repo;
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
        private readonly ILogger<HomeController> _logger;
        private readonly MyDbContext _context;
        protected PersonMeth prM;
        public HomeController(ILogger<HomeController> logger,MyDbContext context)
        {
            _logger = logger;
            _context = context;
             prM = new PersonMeth(context);
        }

        public IActionResult Index()
        {
            List<Person> myData = _context.Persons.ToList();
            ViewBag.Persons = myData;  
            
            ViewBag.Pers = prM.trier(myData.ToArray());
            return View();
        }

        public IActionResult Privacy()
        {
            prM.change2();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
