using Domain.Repositories;

namespace Infraestructure.DataAccess
{
    internal class UnitOfWork(BarberBossDbContext dbContext) : IUnitOfWork
    {
        public void Commit()
        {
            dbContext.SaveChanges();
        }
    }
}
