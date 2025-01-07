
using System.Net;

namespace Domain.Exceptions
{
    public class ValidationException : BarberBossException
    {
        public ValidationException(List<string> errors) : base(errors)
        {
        }

        internal override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
    }
}
