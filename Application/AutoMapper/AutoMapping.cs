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
            CreateMap<RequestRegisterBilling, Billing>();
        }

        private void EntityToResponse()
        {
            CreateMap<Billing, DefaultResponse>();
            CreateMap<Billing, ResponseShortBilling>();
        }
    }
}
