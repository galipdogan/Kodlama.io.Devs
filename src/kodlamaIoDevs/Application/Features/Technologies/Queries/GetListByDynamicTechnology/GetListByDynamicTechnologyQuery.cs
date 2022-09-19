using Application.Features.Technologies.Models;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListByDynamicTechnology
{
    public class GetListByDynamicTechnologyQuery : IRequest<TechnologyListModel>
    {
        public Dynamic Dynamic { get; set; }
        public PageRequest PageRequest { get; set; }

    public class GetListByDynamicTechnologyQueryHandler : IRequestHandler<GetListByDynamicTechnologyQuery, TechnologyListModel>
    {
        private readonly IMapper mapper;
        private readonly ITechnologyRepository technologyRepository;
        
        public GetListByDynamicTechnologyQueryHandler(IMapper mapper, ITechnologyRepository technologyRepository, TechnologyBusinessRules technologyBusinessRules)
        {
            this.mapper = mapper;
            this.technologyRepository = technologyRepository;
           
        }

        public async Task<TechnologyListModel> Handle(GetListByDynamicTechnologyQuery request, CancellationToken cancellationToken)
        {
            IPaginate<Technology> technologies = await
                technologyRepository.GetListByDynamicAsync(request.Dynamic,
                include: c => c.Include(c => c.ProgrammingLanguage),
                index: request.PageRequest.Page,
                size: request.PageRequest.PageSize);
            //Businessrules...
            TechnologyListModel technologyListModel =
                mapper.Map<TechnologyListModel>(technologies);
            return technologyListModel;
        }
    }
}
}
