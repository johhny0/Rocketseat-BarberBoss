using Communication.Request;
using FluentValidation;

namespace Application.UseCases.Billings.Register
{
    public class RegisterBillingValidator : AbstractValidator<RequestRegisterBilling>
    {
        public RegisterBillingValidator()
        {
            RuleFor(x => x.Title).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.DueDate).NotEmpty().WithMessage("Due Date is required");
            RuleFor(x => x.PaymentMethod)
                .NotEmpty().WithMessage("Paid is required")
                .IsInEnum().WithMessage("Payment Method is not valid");

            RuleFor(x => x.Value)
                .NotEmpty().WithMessage("Value is required")
                .GreaterThan(0).WithMessage("Value must be greater than 0");
        }
    }

}
