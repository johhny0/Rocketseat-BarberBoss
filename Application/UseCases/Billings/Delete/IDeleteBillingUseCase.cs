
namespace Application.UseCases.Billings.Delete
{
    public interface IDeleteBillingUseCase
    {
        void Execute(Guid id);
    }
}