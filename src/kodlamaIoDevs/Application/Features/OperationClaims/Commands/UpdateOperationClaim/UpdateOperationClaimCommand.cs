using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    internal class UpdateOperationClaimCommand : IRequest<UpdatedOperationClaimDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string[] Roles => new[] { "admin" };
        public class UpdateOperationClaimCommandHandler : IRequestHandler<UpdateOperationClaimCommand, UpdatedOperationClaimDto>
        {
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly IMapper _mapper;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public UpdateOperationClaimCommandHandler(IOperationClaimRepository operationClaimRepository, IMapper mapper, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _operationClaimRepository = operationClaimRepository;
                _mapper = mapper;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<UpdatedOperationClaimDto> Handle(UpdateOperationClaimCommand request, CancellationToken cancellationToken)
            {
                await _operationClaimBusinessRules.OperationClaimNameCanNotBeDuplicatedWhenUpdated(request.Name);

                OperationClaim? mappedOperationClaim = _mapper.Map<OperationClaim>(request);
                OperationClaim updatedOperationClaim = await _operationClaimRepository.UpdateAsync(mappedOperationClaim);
                UpdatedOperationClaimDto updatedOperationClaimDto = _mapper.Map<UpdatedOperationClaimDto>(updatedOperationClaim);

                return updatedOperationClaimDto;
            }
        }
    }
}
