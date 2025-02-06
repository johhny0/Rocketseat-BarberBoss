using Application.UseCases.Users.Resources;
using Communication.Request;
using FluentValidation;

namespace Application.UseCases.Users
{
    public class UserValidator : AbstractValidator<RequestUser>
    {
        public UserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(UserValidationResource.NAME_REQUIRED);

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(UserValidationResource.EMAIL_REQUIRED)
                .EmailAddress()
                .When(x => !string.IsNullOrWhiteSpace(x.Email), ApplyConditionTo.CurrentValidator)
                .WithMessage(UserValidationResource.EMAIL_INVALID);

            RuleFor(x => x.Password).SetValidator(new PasswordValidatior<RequestUser>());

        }
    }
}
