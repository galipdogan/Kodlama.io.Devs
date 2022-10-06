using Application.Features.OperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Core.Security.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetListOperationClaim
{
    public class GetListOperationClaimQuery:IRequest<OperationClaimListModel>
    {
        public PageRequest PageRequest { get; set; }
        public class GetListOperationClaimQueryHandler:IRequestHandler<GetListOperationClaimQuery, OperationClaimListModel>
        {
            IMapper _mapper;
            IOperationClaimRepository _operationClaimRepository;

            public GetListOperationClaimQueryHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
            }

            public async Task<OperationClaimListModel>Handle(GetListOperationClaimQuery request, CancellationToken cancellationToken)
            {
                IPaginate<OperationClaim> operationClaim = await _operationClaimRepository.GetListAsync(//include:
                                                                                                        //s => s.Include(u => u.User),
                                                                                                        index:request.PageRequest.Page, 
                                                                                                        size: request.PageRequest.PageSize);
                OperationClaimListModel mappedOperationClaimListModel=_mapper.Map<OperationClaimListModel>(operationClaim);
                return mappedOperationClaimListModel;
            }

            /*
             public async Task<SocialMediaListModel> Handle(GetListSocialMediaQuery request, CancellationToken cancellationToken)
            {
                IPaginate<SocialMedia> socialMedia = await _socialMediaRepository.GetListAsync(include:
                                                                                               s => s.Include(u => u.User),
                                                                                               index:request.PageRequest.Page, 
                                                                                               size: request.PageRequest.PageSize); 

                SocialMediaListModel mappedSocialMediaListModel = _mapper.Map<SocialMediaListModel>(socialMedia);
                return mappedSocialMediaListModel;
            }*/
        }
    }
}
