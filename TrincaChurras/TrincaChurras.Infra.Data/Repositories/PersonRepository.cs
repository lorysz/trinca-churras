using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrincaChurras.Domain.Entities;
using TrincaChurras.Domain.Interfaces.Repositories;
using TrincaChurras.Infra.Data.Contexts;

namespace TrincaChurras.Infra.Data.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        protected readonly TrincaChurrasContext _context;

        public PersonRepository(TrincaChurrasContext context)
        {
            _context = context;
        }

        public async Task<List<User>> BuscarTodos()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Cadastrar(User value)
        {
            await _context.Users.AddAsync(value);
            await _context.SaveChangesAsync();
        }
    }
}
