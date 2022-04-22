using AutoMapper;
using ShopsRUs.API.Models.DTOs;
using ShopsRUs.API.Models.Entities;

namespace ShopsRUs.API.Mappers
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Users, CustomerUsersDto>()
                .ForMember(x => x.UserId, x => x.MapFrom(c => c.Id))
                .ForMember(x => x.CreatedOnDate, x => x.MapFrom(c => c.CreatedOnDate.Date.ToString("yyyy-MM-dd")));

            CreateMap<CreateCustomerUserDto, Users>();
        }
    }
}
