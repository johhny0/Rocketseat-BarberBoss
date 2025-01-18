using Infraestructure.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Infraestructure.Migrations
{
    public static class DataBaseMigration
    {
        public static async Task MigrateDataBase(IServiceProvider provider)
        {
            var context = provider.GetRequiredService<BarberBossDbContext>();

            await context.Database.MigrateAsync();
        }
    }
}
