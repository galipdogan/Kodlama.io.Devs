using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Application.Features.Users.Commands.UpdateUser.UpdateUserCommand;

namespace Application.Features.Users.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator()

        {
            RuleFor(pl => pl.Id).NotEmpty();
            
        }

    }
}
