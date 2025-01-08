using Communication.Request;
using Communication.Response;

namespace Application.UseCases.Billings.Register
{
    public interface IRegisterBillingUseCase
    {
        DefaultResponse Execute(RequestBilling registerBilling);
    }
}
