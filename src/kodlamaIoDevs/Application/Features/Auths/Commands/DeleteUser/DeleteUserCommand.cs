using Application.Features.Users.Dtos;
using Application.Features.Users.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.DeleteUserCommand
{
    public class DeleteUserCommand : IRequest<DeletedUserDto>
    {
        public int Id { get; set; }

        public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeletedUserDto>
        {
            private readonly IUserRepository _userRepository;
            private readonly IMapper _mapper;
            private readonly UserBusinessRules _userBusinessRules;

            public DeleteUserCommandHandler(IUserRepository userRepository, IMapper mapper, UserBusinessRules userBusinessRules)
            {
                _userRepository = userRepository;
                _mapper = mapper;
                _userBusinessRules = userBusinessRules;
            }

            public async Task<DeletedUserDto> Handle(DeleteUserCommand dpl, CancellationToken cancellationToken)
            {

                await _userBusinessRules.WillBeCheckedBeforeDeleting(dpl.Id);

                User mappedUser = _mapper.Map<User>(dpl);
                User deletedUser = await _userRepository.DeleteAsync(mappedUser);
                DeletedUserDto deletedUserDto = _mapper.Map<DeletedUserDto>(deletedUser);

                return deletedUserDto;

            }


        }
    }
}
