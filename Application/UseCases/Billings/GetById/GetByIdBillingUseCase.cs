using AutoMapper;
using Communication.Response;
using Domain;
using Domain.Exceptions;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.GetById
{
    internal class GetByIdBillingUseCase(
        IBillingsRepository repository,
        IMapper mapper
        ) : IGetByIdBillingUseCase
    {
        public ResponseBilling Execute(Guid id)
        {
            var result = repository.GetById(id)
                ?? throw new ObjectNotFound(nameof(Billing), id);

            return mapper.Map<ResponseBilling>(result);
        }
    }
}
