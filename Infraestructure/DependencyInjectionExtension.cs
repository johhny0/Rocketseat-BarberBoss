using Domain.Repositories;
using Domain.Repositories.Billings;
using Infraestructure.DataAccess;
using Infraestructure.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infraestructure
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            AddDbContext(services, configuration);

            AddRepositories(services);

            return services;
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("MySqlConnection");

            var version = new Version(8, 0, 30);
            var serverVersion = new MySqlServerVersion(version);

            services.AddDbContext<BarberBossDbContext>(config =>
                config.UseMySql(connectionString, serverVersion));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IBillingsRepository, BillingsRepository>();

        }
    }
}
