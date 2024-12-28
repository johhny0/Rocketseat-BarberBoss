using Application.UseCases.Billings.Register;
using Communication.Request;
using Communication.Response;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillingsController : Controller
    {
        //[ProducesResponseType<List<Billing>>(StatusCodes.Status200OK)]
        //[ProducesResponseType<Billing>(StatusCodes.Status204NoContent)]
        //[ProducesResponseType<ResponseErrors>(StatusCodes.Status400BadRequest)]
        //public IActionResult Index()
        //{
        //    return Ok();
        //}

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

            return Created(string.Empty, new { Id = response });
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
