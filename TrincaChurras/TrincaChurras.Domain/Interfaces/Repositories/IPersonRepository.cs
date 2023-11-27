using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Domain.Entities;

namespace TrincaChurras.Domain.Interfaces.Repositories
{
    public interface IPersonRepository
    {
        Task Cadastrar(User value);
        Task<List<User>> BuscarTodos();
    }
}
