using Communication.Request;

namespace Application.UseCases.Billings.Update
{
    public interface IUpdateBillingUseCase
    {
        void Execute(Guid id, RequestBilling requestUpdate);
    }
}