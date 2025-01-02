using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.DataAccess
{
    public class BarberBossDbContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<Billing> Billings { get; set; }
    }
}
