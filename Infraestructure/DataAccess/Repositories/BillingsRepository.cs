using Domain;
using Domain.Repositories.Billings;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.DataAccess.Repositories
{
    internal class BillingsRepository(BarberBossDbContext dbContext) : IBillingsWriteOnlyRepository, IBillingsUpdateOnlyRepository, IBillingsRemoveOnlyRepository, IBillingsReadOnlyRepository
    {
        public void Add(Billing billing)
        {
            dbContext.Add(billing);
        }

        public List<Billing> GetAll()
        {
            return [.. dbContext.Billings.AsNoTracking()];
        }

        Billing? IBillingsReadOnlyRepository.GetById(Guid id)
        {
            return dbContext.Billings.AsNoTracking().FirstOrDefault(b => b.Id == id);
        }

        Billing? IBillingsUpdateOnlyRepository.GetById(Guid id)
        {
            return dbContext.Billings.Find(id);
        }

        public bool Remove(Guid id)
        {
            var billing = dbContext.Billings.Find(id);

            if (billing is null)
                return false;

            dbContext.Remove(billing);

            return true;
        }

        public void Update(Billing billing)
        {

            dbContext.Billings.Update(billing);
        }
    }
}
