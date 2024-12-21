namespace Domain.Exceptions
{
    public abstract class BarberBossException : Exception
    {
        public List<string> ErrorsMessage { get; set; }

        public BarberBossException(string message)
        {
            ErrorsMessage = [message];
        }

        public BarberBossException(List<string> errors)
        {
            ErrorsMessage = errors;
        }
    }
}
