using Application.Services.Repositories;
using Core.Persistence.Paging;
using Domain.Entities;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Security.Entities;
using Core.Security.Hashing;
using Core.Security.Dtos;

namespace Application.Features.Users.Rules
{
    public class UserBusinessRules
    {
        private readonly IUserRepository _userRepository;

        public UserBusinessRules(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task EmailCanNotBeDuplicatedWhenInsterted(string eMail)
        {
            IPaginate<UserForLoginDto> result = (IPaginate<UserForLoginDto>)await _userRepository.GetListAsync(b => b.Email == eMail);
            if (result.Items.Any()) throw new BusinessException("Email has already exists.");
        }

        public async Task EMailIsRequired(UserForLoginDto userForLoginDto)
        {
            if (userForLoginDto == null) throw new BusinessException("Required email is null. Check the mail adress.");
        }

        public async Task PasswordCheck(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            bool result = HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);
            if (!result) throw new BusinessException("Wrong Password");
        }

        public async Task WillBeCheckedBeforeDeleting(int id)
        {
            var entity = await _userRepository.GetAsync(x => x.Id == id);
            if (entity == null)
                throw new BusinessException("Deleted record was not found");
        }

        public async Task UserVerifyBusinessRule(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            HashingHelper.VerifyPasswordHash(password, passwordHash, passwordSalt);

        }
        
        public async Task UserNameShouldExistWhenRequested(User user)
        {
            if (user == null) throw new BusinessException("User must exist.");
        }
    }
}
