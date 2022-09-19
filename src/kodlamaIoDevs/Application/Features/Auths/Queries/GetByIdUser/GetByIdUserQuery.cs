using Application.Features.Users.Dtos;
using Application.Features.Users.Models;
using Application.Features.Users.Queries.GetListUser;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.GetByIdUser
{
    public class GetByIdUserQuery : IRequest<UserGetByIdDto>
    {
        public int Id { get; set; }

        public class GetByIdUserQueryHandler : IRequestHandler<GetByIdUserQuery, UserGetByIdDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusiness;

            public GetByIdUserQueryHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusiness = userBusinessRules;

            }

            public async Task<UserGetByIdDto> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
            {
                User? user = await _userRepository.GetAsync(b => b.Id == request.Id);
                _userBusiness.UserNameShouldExistWhenRequested(user);
                UserGetByIdDto userGetByIdDto = _mapper.Map<UserGetByIdDto>(user);
                return userGetByIdDto;
            }
        }

    }
    
}


