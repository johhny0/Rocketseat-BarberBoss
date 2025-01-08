namespace Domain.Repositories.Billings
{
    public interface IBillingsUpdateOnlyRepository
    {
        Billing? GetById(Guid id);
        void Update(Billing billing);
    }
}
