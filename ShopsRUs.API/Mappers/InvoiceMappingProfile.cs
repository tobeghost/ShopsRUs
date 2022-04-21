using AutoMapper;
using ShopsRUs.API.Models.DTOs;
using ShopsRUs.API.Models.Entities;

namespace ShopsRUs.API.Mappers
{
    public class InvoiceMappingProfile : Profile
    {
        public InvoiceMappingProfile()
        {
            CreateMap<Invoice, InvoiceDto>()
               .ForMember(cdto => cdto.InvoiceId, copt => copt.MapFrom(c => c.Id))
               .ForMember(cdto => cdto.CreatedOnDate, opt => opt.MapFrom(c => c.CreatedOnDate.Date.ToString("yyyy-MM-dd")));
        }
    }
}
