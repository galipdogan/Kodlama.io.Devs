using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Queries.GetByIdProgrammingLanguage
{
    public class GetByIdProgrammingLanguageQuery : IRequest<GetByIdDtoProgrammingLanguage>
    {
        public int Id { get; set; }

        public class GetByIdProgrammingLanguageQueryHandler : IRequestHandler<GetByIdProgrammingLanguageQuery, GetByIdDtoProgrammingLanguage>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRules _programmingLanguageBusinessRules;

            public GetByIdProgrammingLanguageQueryHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRules programmingLanguageBusinessRules)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRules = programmingLanguageBusinessRules;

            }

            public async Task<GetByIdDtoProgrammingLanguage> Handle(GetByIdProgrammingLanguageQuery request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? mappedProgrammingLanguage = await _programmingLanguageRepository.GetAsync(b => b.Id == request.Id);
                _programmingLanguageBusinessRules.ProgrammingLanguageNameShouldExistWhenRequested(mappedProgrammingLanguage);
                GetByIdDtoProgrammingLanguage programmingLanguageGetByIdDto = _mapper.Map<GetByIdDtoProgrammingLanguage>(mappedProgrammingLanguage);
                return programmingLanguageGetByIdDto;
            }
        }

    }

}


