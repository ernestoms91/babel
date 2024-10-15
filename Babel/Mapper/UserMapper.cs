using AutoMapper;
using Babel.Models;
using Babel.Models.Dtos;

namespace Babel.Mapper
{
    public class UserMapper: Profile
    {
        public UserMapper()
        {
            CreateMap<User, UserDto>()
            .ForMember(dest => dest.Roles,
                       opt => opt.MapFrom(src => src.UserRoles.Select(ur => ur.Role.RoleName))) // Mapeo de nombres de roles
            .ReverseMap();
        }
    }
}
