
namespace Application.UseCases.Billings.Delete
{
    public interface IDeleteBillingUseCase
    {
        bool Execute(Guid id);
    }
}