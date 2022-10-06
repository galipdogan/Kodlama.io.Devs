using Application.Features.Technologies.Dtos;
using Application.Features.UserOperationClaims.Dtos;
using Application.Features.UserOperationClaims.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.UserOperationClaims.Queries.GetUserOperationClaimByUserId;

public class GetUserOperationClaimsByUserIdQuery : IRequest<UserOperationClaimListModel>
{
    public int UserId { get; set; }

    public class GetUserOperationClaimByUserIdQueryHandler : IRequestHandler<GetUserOperationClaimsByUserIdQuery, UserOperationClaimListModel>
    {
        private readonly IUserOperationClaimRepository _userOperationClaimRepository;
        private readonly IMapper _mapper;

        public GetUserOperationClaimByUserIdQueryHandler(IUserOperationClaimRepository userOperationClaimRepository, IMapper mapper)
        {
            _userOperationClaimRepository = userOperationClaimRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationClaimListModel> Handle(GetUserOperationClaimsByUserIdQuery request,
            CancellationToken cancellationToken)
        {
            IPaginate<UserOperationClaim> userOperationClaim = await _userOperationClaimRepository.GetListAsync(u => u.UserId == request.UserId,
                                                                                                                     include: m => m.Include(c => c.User).
                                                                                                                     Include(c => c.OperationClaim));
            UserOperationClaimListModel? userOperationClaimsGetByUserIdDto = _mapper.Map<UserOperationClaimListModel>(userOperationClaim);
            return userOperationClaimsGetByUserIdDto;
        }

        //public async Task<UserOperationClaimsGetByUserIdDto> Handle(GetUserOperationClaimsByUserIdQuery request, CancellationToken cancellationToken)
        //{
        //    UserOperationClaim? userOperationClaim = await _userOperationClaimRepository.GetListAsync(include:
        //        m => m.Include(c => c.User.FirstName)
        //       .Include(c => c.OperationClaim.Name),
        //        b => b.UserId == request.UserId) ;
        //    //_userOperationClaimBusiness.userOperationClaimNameShouldExistWhenRequested(UserOperationClaim);

        //    UserOperationClaimsGetByUserIdDto userOperationClaimsGetByUserIdDto = _mapper.Map<UserOperationClaimsGetByUserIdDto>(userOperationClaim);
        //    return userOperationClaimsGetByUserIdDto;
        //}
    }
}