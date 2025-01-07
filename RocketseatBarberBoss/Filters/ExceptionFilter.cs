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
            context.HttpContext.Response.StatusCode = exception.GetStatusCode();

            var errors = new ResponseErrors(exception.ErrorsMessage);

            context.Result = new ObjectResult(errors);
        }

        private static void HandleUnkowException(ExceptionContext context)
        {
            var responseErrors = new ResponseErrors(ExceptionFilterResource.UNKNOW_ERROR);

            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Result = new ObjectResult(responseErrors);
        }
    }
}
