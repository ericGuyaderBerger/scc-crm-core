using AutoMapper;
using SccCrmCore.Models.Dto;
using SccCrmCore.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SccCrmCore.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SirenForInsertDto, Siren>();
        }
    }
}
