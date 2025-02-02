namespace Communication.Request
{
    public class RequestLogin
    {
        public required string Email { get; set; } 
        public required string Password { get; set; }
    }
}
