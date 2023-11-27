using Microsoft.Azure.Cosmos;
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
    public class ChurrasRepository : IChurrasRepository
    {
        protected readonly TrincaChurrasContext _context;

        public ChurrasRepository(TrincaChurrasContext context)
        {
            _context = context;
        }

        public async Task AceitarConvite(string id, string idUser)
        {
            var user = await _context.Users.Where(x => x.Id == idUser).FirstOrDefaultAsync();

            if (user != null)
            {
                var churrasco = await _context.Churrascos.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (churrasco != null)
                {
                    var participante = churrasco.Participantes.Where(x => x.IdUser == idUser).FirstOrDefault();

                    if (participante != null)
                    {
                        participante.Aceitou = true;
                    }
                    else
                    {
                        churrasco.Participantes.Add(new Participante { Aceitou = true, Nome = user.Nome, IdUser = idUser });

                    }

                    _context.Update(churrasco);
                    await _context.SaveChangesAsync();
                }
            }
        }

        public async Task<List<Churrasco>> BuscarChurrasComAval()
        {
            return await _context.Churrascos.Where(x => x.SocioConfirmou).ToListAsync();
        }

        public async Task<List<Churrasco>> BuscarChurrasSemAval()
        {
            return await _context.Churrascos.Where(x => !x.SocioConfirmou).ToListAsync();
        }

        public async Task Cadastrar(Churrasco value)
        {
            await _context.Churrascos.AddAsync(value);
            await _context.SaveChangesAsync();
        }

        public async Task ConfirmarAval(string id)
        {
            var churrasco = await _context.Churrascos.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (churrasco != null)
            {
                churrasco.SocioConfirmou = true;
                _context.Churrascos.Update(churrasco);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RejeitarConvite(string id, string idUser)
        {
            var user = await _context.Users.Where(x => x.Id == idUser).FirstOrDefaultAsync();

            if (user != null)
            {
                var churrasco = await _context.Churrascos.Where(x => x.Id == id).FirstOrDefaultAsync();

                if (churrasco != null)
                {
                    var participante = churrasco.Participantes.Where(x => x.IdUser == idUser).FirstOrDefault();

                    if (participante != null)
                    {
                        participante.Aceitou = false;
                    }
                    else
                    {
                        churrasco.Participantes.Add(new Participante { Aceitou = false, Nome = user.Nome, IdUser = idUser });

                    }
                    _context.Update(churrasco);
                    await _context.SaveChangesAsync();
                }
            }
        }
    }
}
