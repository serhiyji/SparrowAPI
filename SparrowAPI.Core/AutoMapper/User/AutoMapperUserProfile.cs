using AutoMapper;
using SparrowAPI.Core.DTOs.User;
using SparrowAPI.Core.Entities.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparrowAPI.Core.AutoMapper.User
{
    public class AutoMapperUserProfile : Profile
    {
        public AutoMapperUserProfile()
        {
            CreateMap<UsersDto, AppUser>().ReverseMap();
            CreateMap<UpdateUserDto, AppUser>().ReverseMap();
            CreateMap<CreateUserDto, AppUser>().ForMember(dst => dst.UserName, act => act.MapFrom(src => src.Email));
            CreateMap<AppUser, CreateUserDto>();
            CreateMap<DeleteUserDto, AppUser>().ReverseMap();
            CreateMap<EditUserDto, AppUser>().ReverseMap();
        }
    }
}
