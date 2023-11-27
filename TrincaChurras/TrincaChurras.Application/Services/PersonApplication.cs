using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Application.DTO;
using TrincaChurras.Application.Interfaces;
using TrincaChurras.Domain.Entities;
using TrincaChurras.Domain.Interfaces.Repositories;
using TrincaChurras.Domain.Interfaces.Services;

namespace TrincaChurras.Application.Services
{
    public class PersonApplication : IPersonApplication
    {
        protected readonly IPersonService _personService;
        protected readonly IMapper _mapper;

        public PersonApplication(IPersonService personService, IMapper mapper)
        {
            _personService = personService;
            _mapper = mapper;
        }

        public async Task<List<ViewUserDTO>> BuscarTodos()
        {
            var userList = await _personService.BuscarTodos();
            return _mapper.Map<List<ViewUserDTO>>(userList);

        }

        public async Task Cadastrar(CreateUserDTO value)
        {
            var user = _mapper.Map<User>(value);
            await _personService.Cadastrar(user);
        }
    }
}
