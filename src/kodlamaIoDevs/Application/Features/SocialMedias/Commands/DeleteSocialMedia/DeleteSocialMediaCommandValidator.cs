using Application.Features.SocialMedias.Dtos;
using Application.Features.SocialMedias.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Commands.DeleteSocialMedia
{
    public class DeleteSocialMediaCommandValidator : AbstractValidator<DeleteSocialMediaCommand>
    {
        public DeleteSocialMediaCommandValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
