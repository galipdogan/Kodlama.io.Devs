using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Core.Security.Dtos;
using Core.Security.Entities;
using Core.Security.JWT;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.LoginUser
{
    public class LoginUserCommand: UserForLoginDto, IRequest<UserForLoginDto>
    {
        public UserForLoginDto LoggedUserDto { get; set; }

        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, UserForLoginDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;
            private readonly IMapper _mapper;
            ITokenHelper _tokenHelper;
            UserBusinessRules _userBusinessRules;

            public LoginUserCommandHandler(IUserRepository userRepository, IMapper mapper, ITokenHelper tokenHelper, UserBusinessRules userBusinessRules, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _tokenHelper = tokenHelper;
                _userBusinessRules = userBusinessRules;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<UserForLoginDto> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {

                User? userToLogin = await _userRepository.GetAsync(u=>u.Email==request.LoggedUserDto.Email);

                await _userBusinessRules.EMailIsRequired(request);

                await _userBusinessRules.UserVerifyBusinessRule(request.LoggedUserDto.Password, userToLogin.PasswordHash, userToLogin.PasswordSalt);

               // await _userBusinessRules.PasswordCheck(request.Password, userForLoginDto.PasswordHash, userForLoginDto.PasswordSalt);

                List<OperationClaim> operationClaims = (await _userOperationClaimRepository.GetListAsync(oc => oc.UserId == userToLogin.Id, include:
                                                            p => p.Include(a => a.OperationClaim))).Items.Select(b => b.OperationClaim).ToList(); 

                AccessToken accessToken = _tokenHelper.CreateToken(userToLogin, operationClaims);
                UserForLoginDto userLoginDto = _mapper.Map<UserForLoginDto>(accessToken);


                return userLoginDto;
            }

        }
    }
}
