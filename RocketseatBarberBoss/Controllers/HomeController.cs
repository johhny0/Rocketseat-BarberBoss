using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new
            {
                Status = HomeControllerResource.SERVER_STATUS,
                Date = DateTime.UtcNow
            });
        }
    }
}
