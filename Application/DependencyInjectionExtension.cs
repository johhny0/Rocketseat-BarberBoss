using Application.AutoMapper;
using Application.UseCases.Billings.Delete;
using Application.UseCases.Billings.GetAll;
using Application.UseCases.Billings.GetById;
using Application.UseCases.Billings.Register;
using Application.UseCases.Billings.Reports;
using Application.UseCases.Billings.Update;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);

            return services;
        }

        private static void AddAutoMapper(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        private static void AddUseCases(IServiceCollection services)
        {
            services.AddScoped<IGetAllBillingUseCase, GetAllBillingUseCase>();
            services.AddScoped<IRegisterBillingUseCase, RegisterBillingUseCase>();
            services.AddScoped<IGetByIdBillingUseCase, GetByIdBillingUseCase>();
            services.AddScoped<IDeleteBillingUseCase, DeleteBillingUseCase>();
            services.AddScoped<IUpdateBillingUseCase, UpdateBillingUseCase>();

            services.AddScoped<IGenerateBillingsReportExcelUseCase, GenerateBillingsReportExcelUseCase>();
            services.AddScoped<IGenerateBillingsReportPdfUseCase, GenerateBillingsReportPdfUseCase>();
        }
    }
}
