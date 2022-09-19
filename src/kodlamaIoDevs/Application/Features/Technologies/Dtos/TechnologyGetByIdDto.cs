﻿using Domain.Entities;

namespace Application.Features.Technologies.Dtos
{
    public class TechnologyGetByIdDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ProgrammingLanguageName { get; set; }
    }
}
