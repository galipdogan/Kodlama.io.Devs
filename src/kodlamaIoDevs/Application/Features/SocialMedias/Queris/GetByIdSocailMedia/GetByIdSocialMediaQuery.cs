using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Features.Technologies.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Queris.GetByIdSocailMedia
{
    public class GetByIdSocialMediaQuery : IRequest<SocialMediaGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdSocaialMediaQueryHandler : IRequestHandler<GetByIdSocialMediaQuery, SocialMediaGetByIdDto>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;


            public async Task<SocialMediaGetByIdDto> Handle(GetByIdSocialMediaQuery request, CancellationToken cancellationToken)
            {
                SocialMedia? socialMedia = await _socialMediaRepository.GetAsync(sc => sc.Id == request.Id);
                _socialMediaBusinessRules.SocialMediaNameShouldExistWhenRequested(socialMedia);
                SocialMediaGetByIdDto socialMediaGetByIdDto = _mapper.Map<SocialMediaGetByIdDto>(socialMedia);
                return socialMediaGetByIdDto;
            }
        }
    }
}
