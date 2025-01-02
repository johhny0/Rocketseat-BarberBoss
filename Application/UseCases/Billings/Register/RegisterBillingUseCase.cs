using AutoMapper;
using Communication.Request;
using Communication.Response;
using Domain;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.Register
{
    internal class RegisterBillingUseCase(
        IMapper mapper,
        IBillingsRepository repository,
        IUnitOfWork unitOfWork) 
        : IRegisterBillingUseCase
    {

        public DefaultResponse Execute(RequestRegisterBilling registerBilling)
        {
            Validate(registerBilling);

            var billing = mapper.Map<Billing>(registerBilling);

            repository.Add(billing);

            unitOfWork.Commit();

            return mapper.Map<DefaultResponse>(billing);
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
