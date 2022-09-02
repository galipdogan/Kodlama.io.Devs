using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Rules
{
    public class ProgrammingLanguageBusinessRules
    {
        private readonly IProgrammingLanguageRepository _programmingLanguageRepository;

        public ProgrammingLanguageBusinessRules(IProgrammingLanguageRepository programmingLanguageRepository)
        {
            _programmingLanguageRepository = programmingLanguageRepository;
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<ProgrammingLanguage> programmingLanguage = await _programmingLanguageRepository.GetListAsync(pl => pl.Name == name);
            if (programmingLanguage.Items.Any()) throw new BusinessException("Programming language name exists.");
        }

        public async Task ProgrammingLanguageNameCanNotBeDuplicatedWhenUpdated(string name)
        {
            IPaginate<ProgrammingLanguage> result = await _programmingLanguageRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Programming language name exists.");
        }

        public async Task ProgrammingLanguageNameShouldExistWhenRequested(ProgrammingLanguage programmingLanguage)
        {
            if (programmingLanguage == null) throw new BusinessException("Requested programming language does not exists.");
        }
    }
}
