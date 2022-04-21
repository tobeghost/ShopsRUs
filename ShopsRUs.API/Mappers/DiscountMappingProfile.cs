using AutoMapper;
using ShopsRUs.API.Models.DTOs;
using ShopsRUs.API.Models.Entities;

namespace ShopsRUs.API.Mappers
{
    public class DiscountMappingProfile : Profile
    {
        public DiscountMappingProfile()
        {
            CreateMap<Discounts, DiscountDto>()
               .ForMember(cdto => cdto.DiscountId, copt => copt.MapFrom(c => c.Id))
               .ForMember(cdto => cdto.CreatedOnDate, opt => opt.MapFrom(c => c.CreatedOnDate.Date.ToString("yyyy-MM-dd")));

            CreateMap<CreateDiscountDto, Discounts>();
        }
    }
}
