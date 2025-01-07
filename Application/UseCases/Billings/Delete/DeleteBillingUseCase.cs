using AutoMapper;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.Delete
{
    public class DeleteBillingUseCase(IBillingsRemoveOnlyRepository repository) : IDeleteBillingUseCase
    {
        public bool Execute(Guid id)
        {
            repository.Remove(id);
            return false;
        }
    }
}
