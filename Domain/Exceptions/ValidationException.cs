
namespace Domain.Exceptions
{
    public class ValidationException : BarberBossException
    {
        public ValidationException(List<string> errors) : base(errors)
        {
        }
    }
}
