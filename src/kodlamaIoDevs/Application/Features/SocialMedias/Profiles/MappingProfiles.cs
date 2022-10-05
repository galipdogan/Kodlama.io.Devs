using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.SocialMedias.Commands.CreateSocialMedia;
using Application.Features.SocialMedias.Commands.DeleteSocialMedia;
using Application.Features.SocialMedias.Commands.UpdateSocialMedia;
using Application.Features.SocialMedias.Dtos;
using Application.Features.Technologies.Dtos;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<SocialMedia, CreatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, CreateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, DeletedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, DeleteSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, UpdatedSocialMediaDto>().ReverseMap();
            CreateMap<SocialMedia, UpdateSocialMediaCommand>().ReverseMap();

            CreateMap<SocialMedia, SocialMediaListDto>()
               .ForMember(t => t.UserId, opt => opt.MapFrom(t => t.User.Id))
               .ForMember(t => t.FirstName, opt => opt.MapFrom(t => t.User.FirstName))
               .ForMember(t => t.LastName, opt => opt.MapFrom(t => t.User.LastName))
               .ReverseMap();

            CreateMap<IPaginate<SocialMedia>, SocialMediaListDto>().ReverseMap();


            CreateMap<SocialMedia, SocialMediaGetByIdDto>()
               .ForMember(t => t.UserId, opt => opt.MapFrom(t => t.User.Id))
               .ForMember(t => t.FirstName, opt => opt.MapFrom(t => t.User.FirstName))
               .ForMember(t => t.LastName, opt => opt.MapFrom(t => t.User.LastName))
               .ReverseMap();

            CreateMap<IPaginate<SocialMedia>, SocialMediaGetByIdDto>().ReverseMap();
        }
    }
}
