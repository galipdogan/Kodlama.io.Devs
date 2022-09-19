using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Auths.Commands.LoginUser
{
    public class LoginUserCommandValidation : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidation()
        {
            RuleFor(u => u.Email).NotEmpty().EmailAddress();
            RuleFor(u => u.Password).NotEmpty();
           
        }
    }
}
