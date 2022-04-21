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
                .ForMember(cdto => cdto.UserId, copt => copt.MapFrom(c => c.Id))
                .ForMember(cdto => cdto.JoinedIn, opt => opt.MapFrom(c => c.CreatedOnDate.Date.ToLongDateString()));

            CreateMap<CreateCustomerUserDto, Users>();
        }
    }
}
