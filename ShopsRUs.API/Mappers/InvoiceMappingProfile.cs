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
               .ForMember(x => x.InvoiceId, x => x.MapFrom(c => c.Id))
               .ForMember(x => x.CreatedOnDate, x => x.MapFrom(c => c.CreatedOnDate.Date.ToString("yyyy-MM-dd")));

            CreateMap<CreateInvoiceDto, Invoice>()
                .ForMember(x => x.Id, x => x.Ignore())
                .ForMember(x => x.CreatedOnDate, x => x.Ignore());
        }
    }
}
