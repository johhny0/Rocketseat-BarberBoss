using Communication.Request;
using FluentValidation;

namespace Application.UseCases.Billings
{
    public class BillingValidator : AbstractValidator<RequestBilling>
    {
        public BillingValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(BillingsResource.TITLE_REQUIRED);

            RuleFor(x => x.DueDate)
                .NotEmpty().WithMessage(BillingsResource.DUE_DATE_REQUIRED)
                .Must(BeValidDate).WithMessage(BillingsResource.DUE_DATE_INVALID);

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage(BillingsResource.PAYMENT_METHOD_REQUIRED)
                .IsInEnum().WithMessage(BillingsResource.PAYMENT_METHOD_NOT_VALID);

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage(BillingsResource.VALUE_REQUIRED)
                .GreaterThan(0).WithMessage(BillingsResource.VALUE_GREATER_THAN_ZERO);
        }

        private bool BeValidDate(string? dueDate)
        {
            return string.IsNullOrWhiteSpace(dueDate) || DateTime.TryParse(dueDate, out _);
        }
    }

}
