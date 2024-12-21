using Microsoft.AspNetCore.Mvc;

namespace RocketseatBarberBoss.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { 
                Status = "Connected",
                Date = DateTime.UtcNow
            });
        }
    }
}
