using Communication.Response;
using Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            if (context.Exception is BarberBossException)
            {
                HandleProjectException(context);
            }
            else
            {
                HandleUnkowException(context);
            }
        }

        private void HandleProjectException(ExceptionContext context)
        {

            ResponseErrors errorsResponse;
            int statusCode;

            if (context.Exception is ValidationException validationException)
            {
                errorsResponse = new ResponseErrors(validationException.ErrorsMessage);
                statusCode = StatusCodes.Status400BadRequest;
            }
            else
            {
                errorsResponse = new ResponseErrors(context.Exception.Message);
                statusCode = StatusCodes.Status400BadRequest;
            }

            context.HttpContext.Response.StatusCode = statusCode;
            context.Result = new BadRequestObjectResult(errorsResponse);
        }

        private void HandleUnkowException(ExceptionContext context)
        {
            var errorRespose = new ResponseErrors("Unexpected error occours in server");

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorRespose);
        }
    }
}
