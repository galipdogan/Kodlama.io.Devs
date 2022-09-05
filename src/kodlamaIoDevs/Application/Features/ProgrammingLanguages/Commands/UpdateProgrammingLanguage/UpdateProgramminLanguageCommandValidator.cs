using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage.UpdateProgramminLanguageCommand;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgramminLanguageCommandValidator : AbstractValidator<UpdateProgrammingLanguageCommand>
    {
        public UpdateProgramminLanguageCommandValidator()

        {
            RuleFor(pl => pl.Id).NotEmpty();
            RuleFor(pl => pl.Name).NotEmpty();          
        }

    }
}
