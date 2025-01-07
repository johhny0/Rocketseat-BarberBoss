using AutoMapper;
using Communication.Response;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.GetAll
{
    internal class GetAllBillingUseCase(
        IBillingsReadOnlyRepository repository,
        IMapper mapper) : IGetAllBillingUseCase
    {

        public ResponseAllBillings Execute()
        {
            var result = repository.GetAll();

            return mapper.Map<ResponseAllBillings>(result);
        }
    }

}
