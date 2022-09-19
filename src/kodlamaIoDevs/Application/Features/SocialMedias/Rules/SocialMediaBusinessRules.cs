using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SocialMedias.Rules
{
    public class SocialMediaBusinessRules
    {
        private readonly ISocialMediaRepository _socialMediaRepository;

        public SocialMediaBusinessRules(ISocialMediaRepository socialMediaRepository)
        {
            _socialMediaRepository = socialMediaRepository;
        }

        public async Task SocialMediaNameCanNotBeDuplicatedWhenInserted(string link)
        {
            IPaginate<SocialMedia> socialMedia = await _socialMediaRepository.GetListAsync(pl => pl.Link == link);
            if (socialMedia.Items.Any()) throw new BusinessException("SocialMedia name exists.");
        }

        public async Task SocialMediaNameCanNotBeDuplicatedWhenUpdated(string link)
        {
            IPaginate<SocialMedia> result = await _socialMediaRepository.GetListAsync(b => b.Link == link);
            if (result.Items.Any()) throw new BusinessException("SocialMedia name exists.");
        }

        public async Task SocialMediaNameShouldExistWhenRequested(SocialMedia socialMedia)
        {
            if (socialMedia == null) throw new BusinessException("Requested SocialMedia does not exists.");
        }

        public async Task WillBeCheckedBeforeDeleting(int id)
        {
            var entity = await _socialMediaRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException("Deleted record was not found");
        }

    }
}
