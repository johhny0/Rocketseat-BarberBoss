using Domain;
using Domain.Repositories.Billings;

namespace Infraestructure.DataAccess.Repositories
{
    internal class BillingsRepository(BarberBossDbContext dbContext) : IBillingsRepository
    {
        public void Add(Billing billing)
        {
            dbContext.Add(billing);
        }

        public List<Billing> GetAll()
        {
            throw new NotImplementedException();
        }

        public Billing GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Remove(Billing billing)
        {
            throw new NotImplementedException();
        }

        public void Update(Billing billing)
        {
            throw new NotImplementedException();
        }
    }
}
