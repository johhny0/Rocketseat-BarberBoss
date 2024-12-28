using Communication.Request;
using Communication.Response;
using Domain;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.Register
{
    internal class RegisterBillingUseCase(
        IBillingsRepository repository,
        IUnitOfWork unitOfWork) 
        : IRegisterBillingUseCase
    {

        public Guid Execute(RequestRegisterBilling registerBilling)
        {
            Validate(registerBilling);

            var billing = new Billing
            {
                Title = registerBilling.Title!,
                Description = registerBilling.Description,
                DueDate = DateTime.Parse(registerBilling.DueDate!),
                PaymentMethod = (PaymentMethod)registerBilling.PaymentMethod!,
                Value = registerBilling.Value!.Value
            };


            repository.Add(billing);

            unitOfWork.Commit();

            return billing.Id;
        }

        private static void Validate(RequestRegisterBilling registerBilling)
        {
           var validator = new RegisterBillingValidator();

            var result = validator.Validate(registerBilling);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ValidationException(errors);
            }
        }
    }
}
