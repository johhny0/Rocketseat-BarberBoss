using System.Net;

namespace Domain.Exceptions
{
    public class InvalidLoginException : BarberBossException
    {
        internal override HttpStatusCode StatusCode => HttpStatusCode.Unauthorized;

        public InvalidLoginException() : base(ExceptionResource.EMAIL_OR_PASSWORD_INVALID)
        {
            
        }
    }
}
