using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Domain.Entities;
using TrincaChurras.Domain.Interfaces.Repositories;
using TrincaChurras.Domain.Interfaces.Services;

namespace TrincaChurras.Domain.Services
{
    public class ChurrasService : IChurrasService
    {
        protected readonly IChurrasRepository _churrasRepository;

        public ChurrasService(IChurrasRepository churrasRepository)
        {
            _churrasRepository = churrasRepository;
        }

        public async Task AceitarConvite(string id, string idUser)
        {
            await _churrasRepository.AceitarConvite(id, idUser);
        }

        public async Task<List<Churrasco>> BuscarChurrasComAval()
        {
            return await _churrasRepository.BuscarChurrasComAval();
        }

        public async Task<List<Churrasco>> BuscarChurrasSemAval()
        {
            return await _churrasRepository.BuscarChurrasSemAval();
        }

        public async Task Cadastrar(Churrasco value)
        {
            await _churrasRepository.Cadastrar(value);
        }

        public async Task ConfirmarAval(string id)
        {
            await _churrasRepository.ConfirmarAval(id);
        }

        public async Task RejeitarConvite(string id, string idUser)
        {
            await _churrasRepository.RejeitarConvite(id, idUser);
        }
    }
}
