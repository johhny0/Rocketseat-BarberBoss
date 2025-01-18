using Application.UseCases.Billings.Reports;
using AutoMapper;
using Communication.Request;
using Communication.Response;
using Domain;

namespace Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping() 
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity() 
        {
            CreateMap<RequestBilling, Billing>();

            CreateMap<RequestUser, User>()
                .ForMember(dest => dest.Password, config => config.Ignore());
        }

        private void EntityToResponse()
        {
            CreateMap<Billing, DefaultResponse>();
            CreateMap<Billing, ResponseShortBilling>();
            CreateMap<Billing, ResponseBilling>();
            CreateMap<Billing, BillingXls>();

            CreateMap<User, ResponseUser>();
        }
    }
}
