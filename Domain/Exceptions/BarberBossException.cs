namespace Domain.Exceptions
{
    public class BarberBossException : Exception
    {
        public List<string> Errors { get; set; } = [];

        public BarberBossException(string message)
        {
            Errors.Add(message);
        }

        public BarberBossException(List<string> errors)
        {
            Errors = errors;
        }
    }
}
