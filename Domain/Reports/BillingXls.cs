using ClosedXML.Attributes;
using Domain.Enums;

namespace Application.UseCases.Billings.Reports
{
    public class BillingXls
    {
        [XLColumn(Order = 1)]
        public required string Title { get; set; }

        [XLColumn(Order = 2)]
        public string DueDateString => DueDate.ToShortDateString();

        [XLColumn(Order = 3)]
        public string? PaymentMethodDescription => PaymentMethod.GetDescription();

        [XLColumn(Order = 4)]
        public string ValueString => (Value * -1).ToString("C");

        [XLColumn(Order = 5)]
        public string? Description { get; set; }

        [XLColumn(Ignore = true)]   
        public DateTime DueDate { get; set; }

        [XLColumn(Ignore = true)]
        public PaymentMethod PaymentMethod { get; set; }

        [XLColumn(Ignore = true)]
        public decimal Value { get; set; }
    }
}
