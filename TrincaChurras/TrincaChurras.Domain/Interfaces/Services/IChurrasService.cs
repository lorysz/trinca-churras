using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Domain.Entities;

namespace TrincaChurras.Domain.Interfaces.Services
{
    public interface IChurrasService
    {
        Task Cadastrar(Churrasco value);
        Task ConfirmarAval(string id);
        Task AceitarConvite(string id, string idUser);
        Task RejeitarConvite(string id, string idUser);
        Task<List<Churrasco>> BuscarChurrasComAval();
        Task<List<Churrasco>> BuscarChurrasSemAval();
    }
}
