using Communication.Response;

namespace Application.UseCases.Billings.GetAll
{
    public interface IGetAllBillingUseCase
    {
        ResponseAllBillings Execute();
    }
}
