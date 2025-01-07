using AutoMapper;
using Domain;
using Domain.Exceptions;
using Domain.Repositories;
using Domain.Repositories.Billings;

namespace Application.UseCases.Billings.Delete
{
    public class DeleteBillingUseCase(
        IBillingsRemoveOnlyRepository repository,
        IUnitOfWork unitOfWork
        ) : IDeleteBillingUseCase
    {
        public void Execute(Guid id)
        {
            var result = repository.Remove(id);

            if (!result)
            {
                throw new ObjectNotFound(nameof(Billing), id);
            }

            unitOfWork.Commit();
        }
    }
}
