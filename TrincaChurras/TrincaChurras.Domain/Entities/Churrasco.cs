using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrincaChurras.Domain.Entities
{
    public class Churrasco
    {
        public string StreamId { get; set; }
        public string Id { get; set; }
        public bool SocioConfirmou { get; set; } = false;
        public string Razao { get; set; }
        public DateTime Data { get; set; }
        public List<Participante> Participantes { get; set; }

        public Churrasco()
        {
            var newGuid = Guid.NewGuid().ToString();
            Id = newGuid;
            StreamId = newGuid;

            Participantes = new List<Participante>();
        }
    }

    public class Participante
    {
        public string IdUser { get; set; }
        public string Nome { get; set; }
        public bool Aceitou { get; set; }
    }
}
