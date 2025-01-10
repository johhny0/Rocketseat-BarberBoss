using Domain.Enums;

namespace Domain
{
    public class Billing
    {
        public Guid Id { get; set; }
        public required string Title { get; set; }
        public string? Description { get; set; }
        public decimal Value { get; set; }
        public DateTime DueDate { get; set; }
        public PaymentMethod PaymentMethod { get; set; }
    }
}
