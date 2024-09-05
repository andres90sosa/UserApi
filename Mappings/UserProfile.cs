using AutoMapper;
using UserApi.DTOs;
using UserApi.Entities;

namespace UserApi.Mappings
{
    public class UserProfile: Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>();
            CreateMap<UserCreateDto, User>();
        }
    }
}
