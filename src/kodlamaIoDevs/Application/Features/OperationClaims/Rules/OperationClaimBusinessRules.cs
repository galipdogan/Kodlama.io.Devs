using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Core.Security.Entities;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Rules
{
    public class OperationClaimBusinessRules
    {
        private readonly IOperationClaimRepository _operationClaimRepository;

        public OperationClaimBusinessRules(IOperationClaimRepository operationClaimRepository)
        {
            _operationClaimRepository = operationClaimRepository;
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<OperationClaim> operationClaim = await _operationClaimRepository.GetListAsync(pl => pl.Name == name);
            if (operationClaim.Items.Any()) throw new BusinessException("Operation Claim name exists.");
        }

        public async Task OperationClaimNameCanNotBeDuplicatedWhenUpdated(string name)
        {
            IPaginate<OperationClaim> result = await _operationClaimRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Operation Claim name exists.");
        }

        public async Task OperationClaimNameShouldExistWhenRequested(OperationClaim operationClaim)
        {
            if (operationClaim == null) throw new BusinessException("Requested Operation Claim does not exists.");
        }

        public async Task WillBeCheckedBeforeDeleting(int id)
        {
            var entity = await _operationClaimRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException("Deleted record was not found");
        }
    }
}
