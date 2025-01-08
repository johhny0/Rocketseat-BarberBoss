using Application.UseCases.Billings.Delete;
using Application.UseCases.Billings.GetAll;
using Application.UseCases.Billings.GetById;
using Application.UseCases.Billings.Register;
using Application.UseCases.Billings.Update;
using Communication.Request;
using Communication.Response;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingsController : Controller
    {
        [HttpGet]
        [ProducesResponseType<ResponseAllBillings>(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Index([FromServices] IGetAllBillingUseCase usecase)
        {
            var response = usecase.Execute();

            return Ok(response);
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType<ResponseBilling>(StatusCodes.Status200OK)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Get(
            [FromServices] IGetByIdBillingUseCase useCase,
            [FromRoute] Guid id
            )
        {
            var response = useCase.Execute(id);

            return Ok(response);
        }


        [HttpPost]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Create(
            [FromServices] IRegisterBillingUseCase usecase,
            [FromBody] RequestBilling registerbilling
            )
        {
            var response = usecase.Execute(registerbilling);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
        public IActionResult Update(
            [FromRoute] Guid id, 
            [FromBody] RequestBilling updateBilling,
            [FromServices] IUpdateBillingUseCase usecase
            )
        {
            usecase.Execute(id, updateBilling);

            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult Delete(
            [FromServices] IDeleteBillingUseCase useCase,
            [FromRoute] Guid id
            )
        {
            useCase.Execute(id);

            return NoContent();
        }


    }
}
