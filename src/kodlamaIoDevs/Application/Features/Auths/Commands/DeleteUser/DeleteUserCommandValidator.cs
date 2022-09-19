using Application.Features.Users.Commands.DeleteUserCommand;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KodlamaIODevs.Application.Features.Users.Commands.Delete
{
    public class DeleteUserValidator : AbstractValidator<DeleteUserCommand>
    {
        public DeleteUserValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}