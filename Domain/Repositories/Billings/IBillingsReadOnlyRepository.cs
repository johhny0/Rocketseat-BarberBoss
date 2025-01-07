namespace Domain.Repositories.Billings
{
    public interface IBillingsReadOnlyRepository
    {
        List<Billing> GetAll();
        Billing? GetById(Guid id);
    }
}
