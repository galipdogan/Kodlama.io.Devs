using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.CreateSocialMedia
{
    public class CreateSocialMediaCommandValidator : AbstractValidator<CreateSocialMediaCommand>
    {
        public CreateSocialMediaCommandValidator()
        {
            RuleFor(sc => sc.Name).NotNull();
            RuleFor(sc => sc.Link).NotNull();
            RuleFor(sc=>sc.UserId).NotNull();
        }
    }
}
