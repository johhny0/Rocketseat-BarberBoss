namespace Domain.Repositories.Billings
{
    public interface IBillingsRepository
    {

        void Add(Billing billing);
        List<Billing> GetAll();
        Billing GetById(Guid id);
        void Remove(Billing billing);
        void Update(Billing billing);
    }
}
