using Application.UseCases.Users.Register;
using Communication.Request;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpPost]
        [ProducesResponseType<ResponseUser>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public ActionResult Create(
            [FromServices] IRegisterUserUseCase usecase,
            [FromBody] RequestUser request
            )
        {
            var response = usecase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
