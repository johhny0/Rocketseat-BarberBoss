using Application.UseCases.Billings.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IRegisterBillingUseCase, RegisterBillingUseCase>();

            return services;
        }
    }
}
