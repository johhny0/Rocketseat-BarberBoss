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
            if (context.Exception is BarberBossException barberBossException)
            {
                HandleProjectException(context, barberBossException);
            }
            else
            {
                HandleUnkowException(context);
            }
        }

        private static void HandleProjectException(ExceptionContext context, BarberBossException exception)
        {
            if (exception is ObjectNotFound)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status404NotFound;
                context.Result = new NotFoundObjectResult(GetMessages(exception));
            }
            else
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                context.Result = new BadRequestObjectResult(GetMessages(exception));
            }
        }

        private static void HandleUnkowException(ExceptionContext context)
        {
            var responseErrors = new ResponseErrors(ExceptionFilterResource.UNKNOW_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(responseErrors);
        }

        private static ResponseErrors GetMessages(BarberBossException exception)
        {
            return new ResponseErrors(exception.ErrorsMessage);
        }
    }
}
