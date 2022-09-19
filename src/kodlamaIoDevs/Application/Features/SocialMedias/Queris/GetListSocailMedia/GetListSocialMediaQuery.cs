using Application.Features.ProgrammingLanguages.Models;
using Application.Features.SocialMedias.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Queris.GetListSocailMedia
{
    public class GetListSocialMediaQuery:IRequest<SocialMediaListModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListSocialMediaQueryHandler : IRequestHandler<GetListSocialMediaQuery, SocialMediaListModel>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper _mapper;

            public GetListSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                _mapper = mapper;
            }

            public async Task<SocialMediaListModel> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMedia> socialMedia = await _socialMediaRepository.GetListAsync(index: request.PageRequest.Page, size: request.PageRequest.PageSize);
                SocialMediaListModel mappedSocialMediaListModel = _mapper.Map<SocialMediaListModel>(socialMedia);
                return mappedSocialMediaListModel;
            }
        }
    }
}
