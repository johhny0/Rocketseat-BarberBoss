namespace Domain.Repositories.Billings
{
    public interface IBillingsWriteOnlyRepository
    {
        void Add(Billing billing);
    }
}
