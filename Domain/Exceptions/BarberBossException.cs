using System.Net;

namespace Domain.Exceptions
{
    public abstract class BarberBossException : Exception
    {
        internal abstract HttpStatusCode StatusCode { get; }
        public List<string> ErrorsMessage { get; set; }

        public BarberBossException(string message)
        {
            ErrorsMessage = [message];
        }

        public BarberBossException(List<string> errors)
        {
            ErrorsMessage = errors;
        }

        public int GetStatusCode()
        {
            return (int)StatusCode;
        }
    }
}
