﻿using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguageCommand
{
    public class DeleteOperationClaimCommand : IRequest<DeletedProgrammingLanguageDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { "admin" };

        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeletedProgrammingLanguageDto>
=======
    public class DeleteOperationClaimCommand : IRequest<DeletedProgrammingLanguageDto>,ISecuredRequest
    {
        public int Id { get; set; }
        public string[] Roles => new[] { "admin"};
        public class DeleteProgrammingLanguageCommandHandler : IRequestHandler<DeleteOperationClaimCommand, DeletedProgrammingLanguageDto>
>>>>>>> Stashed changes
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public DeleteProgrammingLanguageCommandHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;
            }

            public async Task<DeletedProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguageToDelete = await _programmingLanguageRepository.GetAsync(pl => pl.Id == request.Id);

                await _programmingLanguageBusinessRules.WillBeCheckedBeforeDeleting(request.Id);

                //ProgrammingLanguage mappedProgrammingLanguage = _mapper.Map<ProgrammingLanguage>(request);
                ProgrammingLanguage deletedProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguageToDelete);
                DeletedProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeletedProgrammingLanguageDto>(deletedProgrammingLanguage);

                return deletedProgrammingLanguageDto;

            }


        }
    }
}
