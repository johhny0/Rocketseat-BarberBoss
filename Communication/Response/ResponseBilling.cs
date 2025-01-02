using Domain;

namespace Communication.Response
{
    public class ResponseBilling
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
