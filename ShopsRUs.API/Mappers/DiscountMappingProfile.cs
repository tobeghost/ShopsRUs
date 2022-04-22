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
               .ForMember(x => x.DiscountId, x => x.MapFrom(c => c.Id))
               .ForMember(x => x.CreatedOnDate, x => x.MapFrom(c => c.CreatedOnDate.Date.ToString("yyyy-MM-dd")));

            CreateMap<CreateDiscountDto, Discounts>();
        }
    }
}
