using Domain;

namespace Communication.Request
{
    public class RequestRegisterBilling
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public string? DueDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
