using Microsoft.AspNetCore.Mvc;

namespace RocketseatBarberBoss.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(new { Status = "Connected" });
        }
    }
}
