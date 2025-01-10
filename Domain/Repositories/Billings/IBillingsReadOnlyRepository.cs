
namespace Domain.Repositories.Billings
{
    public interface IBillingsReadOnlyRepository
    {
        List<Billing> GetAll();
        List<Billing> GetBillingsByMonth(DateOnly date);
        Billing? GetById(Guid id);
    }
}
