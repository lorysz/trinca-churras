using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Application.DTO;

namespace TrincaChurras.Application.Interfaces
{
    public interface IChurrasApplication
    {
        Task Cadastrar(CreateChurrasDTO value);
        Task ConfirmarAval(string id);
        Task AceitarConvite(string id, string idUser);
        Task RejeitarConvite(string id, string idUser);
        Task<List<ViewChurrasDTO>> BuscarChurrasComAval();
        Task<List<ViewChurrasDTO>> BuscarChurrasSemAval();
    }
}
