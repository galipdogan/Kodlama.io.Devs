using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaims.Commands.UpdateOperationClaim
{
    internal class UpdateOperationClaimCommandValidator : AbstractValidator<UpdateOperationClaimCommand>
    {
        public UpdateOperationClaimCommandValidator()
        {
            RuleFor(pl => pl.Id).NotEmpty();
            RuleFor(pl => pl.Name).NotEmpty();
        }
    }
}
