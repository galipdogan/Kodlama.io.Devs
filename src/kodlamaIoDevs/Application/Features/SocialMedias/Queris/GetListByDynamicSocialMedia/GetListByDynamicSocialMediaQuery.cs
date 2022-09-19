using Application.Features.SocialMedias.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Queris.GetListByDynamicSocialMedia
{
    public class GetListByDynamicSocialMediaQuery : IRequest<SocialMediaListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

        public class GetListByDynamicSocialMediaQueryHandler : IRequestHandler<GetListByDynamicSocialMediaQuery, SocialMediaListModel>
        {
            private readonly ISocialMediaRepository _socialMediaRepository;
            private readonly IMapper mapper;

            public GetListByDynamicSocialMediaQueryHandler(ISocialMediaRepository socialMediaRepository, IMapper mapper)
            {
                _socialMediaRepository = socialMediaRepository;
                this.mapper = mapper;
            }

            public async Task<SocialMediaListModel> Handle(GetListByDynamicSocialMediaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMedia> technologies = await
                    _socialMediaRepository.GetListByDynamicAsync(request.Dynamic,
                    include: c => c.Include(c => c.UserProfile),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);
                //Businessrules...
                SocialMediaListModel socialMediaListModel =
                    mapper.Map<SocialMediaListModel>(technologies);
                return socialMediaListModel;
            }
        }
    }
}
