using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.CreateUsers
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {

            RuleFor(u => u.userForRegisterDto.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.userForRegisterDto.FirstName).NotEmpty();
            RuleFor(u => u.userForRegisterDto.LastName).NotEmpty();
            RuleFor(u => u.userForRegisterDto.Password).NotEmpty();
            RuleFor(u => u.userForRegisterDto.Password).MinimumLength(4);
        }
    }
}
