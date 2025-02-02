using Application.UseCases.Login.DoLogin;
using Communication.Request;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : Controller
    {
        [HttpPost]
        [ProducesResponseType<ResponseUser>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status401Unauthorized)]
        public IActionResult Login(
            [FromServices] IDoLoginUseCase useCase,
            [FromBody] RequestLogin request
            )
        {
            var response = useCase.Execute(request);

            return Ok(response);
        }
    }
}
