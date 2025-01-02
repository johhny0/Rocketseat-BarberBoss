using Communication.Response;

namespace Application.UseCases.Billings.GetById
{
    public interface IGetByIdBillingUseCase
    {
        ResponseBilling Execute(Guid id);
    }
}
