using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.JWT;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUsers
{
    public class CreateUserCommand :  IRequest<UserForRegisterDto>
    {
        public UserForRegisterDto userForRegisterDto { get; set; }
     

        public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserForRegisterDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly ITokenHelper _tokenHelper;

            public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UserForRegisterDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
            {

                //await _userBusinessRules.EmailCanNotBeDuplicatedWhenInsterted(request);
                            

                User mappedUser = _mapper.Map<User>(request);

                HashingHelper.CreatePasswordHash(request.userForRegisterDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                mappedUser.PasswordHash = passwordHash;
                mappedUser.PasswordSalt = passwordSalt;
                mappedUser.Status=true;
             
                User createdUser = await _userRepository.AddAsync(mappedUser);

                UserOperationClaim userOperationClaim = new UserOperationClaim();
                userOperationClaim.OperationClaimId = 1; // User role
                userOperationClaim.UserId = createdUser.Id;
                await _userOperationClaimRepository.AddAsync(userOperationClaim);

                UserForRegisterDto createdUserDto = _mapper.Map<UserForRegisterDto>(createdUser);
                return createdUserDto;

            }
        }

    }
}
