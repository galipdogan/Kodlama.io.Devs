using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.ProgrammingLanguages.Commands.Delete
{
    public class DeleteOperationClaimValidator : AbstractValidator<DeleteOperationClaimCommand>
    {
        public DeleteOperationClaimValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}