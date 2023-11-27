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
    public class PersonService : IPersonService
    {
        protected readonly IPersonRepository _personRepository;

        public PersonService(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<User>> BuscarTodos()
        {
            return await _personRepository.BuscarTodos();
        }

        public async Task Cadastrar(User value)
        {
            await _personRepository.Cadastrar(value);
        }
    }
}
