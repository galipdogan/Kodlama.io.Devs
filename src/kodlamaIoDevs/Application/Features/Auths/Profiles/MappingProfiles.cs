using Application.Features.Users.Commands.CreateUsers;
using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using AutoMapper;
using Domain.Entities;
using Core.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Application.Features.Users.Commands.DeleteUserCommand;
using Application.Features.Users.Commands.UpdateUser;
using Core.Security.Dtos;
using Core.Security.JWT;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, CreateUserCommand>().ReverseMap();
            CreateMap<User, UserForRegisterDto>().ReverseMap();
            CreateMap<AccessToken, UserForLoginDto>().ReverseMap();
            CreateMap<User, UserForLoginDto>().ReverseMap();

            CreateMap<IPaginate<User>, UserListModel>().ReverseMap(); 

            CreateMap<User, UserListDto>().ReverseMap();
            CreateMap<User, UserGetByIdDto>().ReverseMap();

            CreateMap<User, DeletedUserDto>().ReverseMap();
            CreateMap<User, DeleteUserCommand>().ReverseMap();

            CreateMap<User, UpdatedUserDto>().ReverseMap();
            CreateMap<User, UpdateUserCommand>().ReverseMap();

        }
    }
}
