using Communication.Request;

namespace Application.UseCases.Billings.Register
{
    public interface IRegisterBillingUseCase
    {
        Guid Execute(RequestRegisterBilling registerBilling);
    }
}
