using AutoMapper;
using Communication.Request;
using Domain;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.Update
{
    public class UpdateBillingUseCase(
        IMapper mapper,
        IBillingsUpdateOnlyRepository repository,
        IUnitOfWork unitOfWork
        ) : IUpdateBillingUseCase
    {
        public void Execute(Guid id, RequestBilling requestUpdate)
        {
            Validate(requestUpdate);

            var billing = repository.GetById(id) ?? throw new ObjectNotFound(nameof(Billing), id);

            mapper.Map(requestUpdate, billing);

            repository.Update(billing);

            unitOfWork.Commit();
        }

        private static void Validate(RequestBilling registerBilling)
        {
            var validator = new BillingValidator();

            var result = validator.Validate(registerBilling);

            if (!result.IsValid)
            {
                var errors = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ValidationException(errors);
            }
        }
    }
}
