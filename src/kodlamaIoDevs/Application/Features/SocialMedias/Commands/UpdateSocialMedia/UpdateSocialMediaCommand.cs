using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.UpdateSocialMedia
{
    public class UpdateSocialMediaCommand:IRequest<UpdatedSocialMediaDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Link { get; set; }
        public int UserId  { get; set; }
        public string[] Roles => new[] { "admin" };

        public class UpdateSocialMediaCommandHandler:IRequestHandler<UpdateSocialMediaCommand, UpdatedSocialMediaDto>
        {
            private readonly IMapper _mapper;
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly SocialMediaBusinessRules _socialMediaBusinessRules;

            public UpdateSocialMediaCommandHandler(IMapper mapper, ISocialMediaRepository socialMediaRepository, SocialMediaBusinessRules socialMediaBusinessRules)
            {
                _mapper = mapper;
                _socialMediaRepository = socialMediaRepository;
                _socialMediaBusinessRules = socialMediaBusinessRules;
            }

            public async Task<UpdatedSocialMediaDto> Handle(UpdateSocialMediaCommand request, CancellationToken cancellationToken)
            {
                //await _socialMediaBusinessRules.SocialMediaNameShouldExistWhenRequested(request);
                await _socialMediaBusinessRules.SocialMediaNameCanNotBeDuplicatedWhenUpdated(request.Link);

                SocialMedia? mappedSocialMedia = _mapper.Map<SocialMedia>(request);
                SocialMedia updatedSocialMedia = await _socialMediaRepository.UpdateAsync(mappedSocialMedia);
                UpdatedSocialMediaDto updatedSocialMediaDto = _mapper.Map<UpdatedSocialMediaDto>(updatedSocialMedia);

                return updatedSocialMediaDto;
            }
        }
    }
}
