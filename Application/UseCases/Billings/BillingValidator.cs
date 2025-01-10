using Communication.Request;
using Application.UseCases.Billings.Resources;
using FluentValidation;

namespace Application.UseCases.Billings
{
    public class BillingValidator : AbstractValidator<RequestBilling>
    {
        public BillingValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage(BillingValidationResource.TITLE_REQUIRED);

            RuleFor(x => x.DueDate)
                .NotEmpty().WithMessage(BillingValidationResource.DUE_DATE_REQUIRED)
                .Must(BeValidDate).WithMessage(BillingValidationResource.DUE_DATE_INVALID);

            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage(BillingValidationResource.PAYMENT_METHOD_REQUIRED)
                .IsInEnum().WithMessage(BillingValidationResource.PAYMENT_METHOD_NOT_VALID);

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage(BillingValidationResource.VALUE_REQUIRED)
                .GreaterThan(0).WithMessage(BillingValidationResource.VALUE_GREATER_THAN_ZERO);
        }

        private bool BeValidDate(string? dueDate)
        {
            return string.IsNullOrWhiteSpace(dueDate) || DateTime.TryParse(dueDate, out _);
        }
    }

}
