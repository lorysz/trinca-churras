using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Application.DTO;
using TrincaChurras.Domain.Entities;

namespace TrincaChurras.Application
{
    public class MappingEntities : Profile
    {
        public MappingEntities()
        {
            CreateMap<CreateUserDTO, User>().ReverseMap();
            CreateMap<ViewUserDTO, User>().ReverseMap();
            CreateMap<ViewChurrasDTO, Churrasco>().ReverseMap();
            CreateMap<CreateChurrasDTO, Churrasco>().ReverseMap();
            CreateMap<ViewParticipanteDTO, Participante>().ReverseMap();
        }
    }
}
