using Communication.Request;
using Communication.Response;
using Domain.Exceptions;

namespace Application.UseCases.Billings.Register
{
    public class RegisterBillingUseCase
    {

        public DefaultResponse Execute(RequestRegisterBilling registerBilling)
        {
            Validate(registerBilling);

            return new DefaultResponse { Id = Guid.Empty };
        }

        private void Validate(RequestRegisterBilling registerBilling)
        {
           var validator = new RegisterBillingValidator();

            var result = validator.Validate(registerBilling);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new BarberBossException(errors);
            }
        }
    }
}
