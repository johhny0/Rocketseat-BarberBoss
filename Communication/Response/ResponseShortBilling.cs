namespace Communication.Response
{
    public class ResponseShortBilling
    {
        public Guid Id { get; set; }

        public required string Title { get; set; }

        public decimal Value { get; set; }
    }
}
