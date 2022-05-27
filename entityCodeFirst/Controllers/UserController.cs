using Microsoft.AspNetCore.Mvc;

namespace entityCodeFirst.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
