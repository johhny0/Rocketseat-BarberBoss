using Domain;
using Domain.Repositories.Billings;
using Microsoft.EntityFrameworkCore;

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
            return [.. dbContext.Billings.AsNoTracking()];
        }

        public Billing? GetById(Guid id)
        {
            return dbContext.Billings.Find(id);
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
