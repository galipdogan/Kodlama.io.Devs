using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand : IRequest<DeletedTechnologyDto>
    {
        public int Id { get; set; }
        public class DeleteTechnologyCommandHandler:IRequestHandler<DeleteTechnologyCommand, DeletedTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRules _technologyBusinessRules;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRules technologyBusinessRules)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRules = technologyBusinessRules;
            }

            public async Task<DeletedTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRules.WillBeCheckedBeforeDeleting(request.Id);

                Technology technology=_mapper.Map<Technology>(request);  
                Technology deletedTecnology=await _technologyRepository.DeleteAsync(technology);
                DeletedTechnologyDto  deletedTechnologyDto  = _mapper.Map<DeletedTechnologyDto>(deletedTecnology);

                return deletedTechnologyDto;

            }
        }
    }
}
