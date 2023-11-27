using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Application.DTO;
using TrincaChurras.Application.Interfaces;
using TrincaChurras.Domain.Entities;
using TrincaChurras.Domain.Interfaces.Services;

namespace TrincaChurras.Application.Services
{
    public class ChurrasApplication : IChurrasApplication
    {
        protected readonly IChurrasService _churrasService;
        protected readonly IMapper _mapper;

        public ChurrasApplication(IChurrasService churrasService, IMapper mapper)
        {
            _churrasService = churrasService;
            _mapper = mapper;
        }

        public async Task AceitarConvite(string id, string idUser)
        {
            await _churrasService.AceitarConvite(id, idUser);
        }

        public async Task<List<ViewChurrasDTO>> BuscarChurrasComAval()
        {
            var listaChurrasco = await _churrasService.BuscarChurrasComAval();

            return _mapper.Map<List<ViewChurrasDTO>>(listaChurrasco);
        }

        public async Task<List<ViewChurrasDTO>> BuscarChurrasSemAval()
        {
            var listaChurrasco = await _churrasService.BuscarChurrasSemAval();

            return _mapper.Map<List<ViewChurrasDTO>>(listaChurrasco);
        }

        public async Task Cadastrar(CreateChurrasDTO value)
        {
            var churrasco = _mapper.Map<Churrasco>(value);
            await _churrasService.Cadastrar(churrasco);
        }

        public async Task ConfirmarAval(string id)
        {
            await _churrasService.ConfirmarAval(id);
        }

        public async Task RejeitarConvite(string id, string idUser)
        {
            await _churrasService.RejeitarConvite(id, idUser);
        }
    }
}
