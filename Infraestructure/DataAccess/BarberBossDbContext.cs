using Domain;
using Microsoft.EntityFrameworkCore;

namespace Infraestructure.DataAccess
{
    internal class BarberBossDbContext(DbContextOptions options) : DbContext(options)
    {
        public required DbSet<Billing> Billings { get; set; }
        public required DbSet<User> Users { get; set; }
    }
}
