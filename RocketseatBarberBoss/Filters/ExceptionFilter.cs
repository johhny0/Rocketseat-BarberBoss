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

        private static void HandleProjectException(ExceptionContext context)
        {
            if (context.Exception is ValidationException validationException)
            {
                BadRequest(context, new ResponseErrors(validationException.ErrorsMessage));
            }
            else
            {
                BadRequest(context, new ResponseErrors(context.Exception.Message));
            }
        }

        private static void HandleUnkowException(ExceptionContext context)
        {
            var responseErrors = new ResponseErrors(ExceptionFilterResource.UNKNOW_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(responseErrors);
        }

        private static void BadRequest(ExceptionContext context, ResponseErrors responseErrors)
        {
            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new BadRequestObjectResult(responseErrors);
        }
    }
}
