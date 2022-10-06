using Application.Features.OperationClaims.Dtos;
using Application.Features.OperationClaims.Rules;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.Security.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Queries.GetByIdOperationClaim
{
    public class GetByIdOperationClaimQuery : IRequest<OperationClaimGetByIdDto>
    {
        public int Id { get; set; }
        public class GetByIdOperationClaimQueryQueryHandler : IRequestHandler<GetByIdOperationClaimQuery, OperationClaimGetByIdDto>
        {
            private readonly IMapper _mapper;
            private readonly IOperationClaimRepository _operationClaimRepository;
            private readonly OperationClaimBusinessRules _operationClaimBusinessRules;

            public GetByIdOperationClaimQueryQueryHandler(IMapper mapper, IOperationClaimRepository operationClaimRepository, OperationClaimBusinessRules operationClaimBusinessRules)
            {
                _mapper = mapper;
                _operationClaimRepository = operationClaimRepository;
                _operationClaimBusinessRules = operationClaimBusinessRules;
            }

            public async Task<OperationClaimGetByIdDto> Handle(GetByIdOperationClaimQuery request, CancellationToken cancellationToken)
            {
                OperationClaim mappedOperationClaim = await _operationClaimRepository.GetAsync(b => b.Id == request.Id);
                await _operationClaimBusinessRules.OperationClaimNameShouldExistWhenRequested(mappedOperationClaim);
                OperationClaimGetByIdDto getByIdOperationClaimDto=_mapper.Map<OperationClaimGetByIdDto>(mappedOperationClaim);
                return getByIdOperationClaimDto;


            }
        }
    }
}
