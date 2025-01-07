namespace Domain.Repositories.Billings
{
    public interface IBillingsRemoveOnlyRepository
    {
        bool Remove(Guid id);
    }
}
