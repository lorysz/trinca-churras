using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Application.DTO;

namespace TrincaChurras.Application.Interfaces
{
    public interface IPersonApplication
    {
        Task Cadastrar(CreateUserDTO value);
        Task<List<ViewUserDTO>> BuscarTodos();
    }
}
