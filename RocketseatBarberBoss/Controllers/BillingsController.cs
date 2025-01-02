using Application.UseCases.Billings.GetAll;
using Application.UseCases.Billings.Register;
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
        [ProducesResponseType<ResponseAllBillings>(StatusCodes.Status204NoContent)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Index([FromServices] IGetAllBillingUseCase usecase)
        {
            var response = usecase.Execute();

            return Ok(response);
        }

        //[HttpGet]
        //[Route("{id}")]
        //[ProducesResponseType<Billing>(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        //public IActionResult Get(Guid id)
        //{
        //    return Ok();
        //}


        [HttpPost]
        [ProducesResponseType<DefaultResponse>(StatusCodes.Status201Created)]
        [ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        public IActionResult Create(
            [FromServices] IRegisterBillingUseCase usecase,
            [FromBody] RequestRegisterBilling registerbilling
            )
        {
            var response = usecase.Execute(registerbilling);

            return Created(string.Empty, response);
        }

        //[HttpPut]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(typeof(ResponseErrors), StatusCodes.Status400BadRequest)]
        //public IActionResult Update([FromRoute] Guid id, [FromBody] RequestUpdateBilling updateBilling)
        //{
        //    return NoContent();
        //}

        //[HttpDelete]
        //[Route("{id}")]
        //[ProducesResponseType(StatusCodes.Status204NoContent)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //public IActionResult Delete([FromRoute] Guid id)
        //{
        //    return NoContent();
        //}


    }
}
