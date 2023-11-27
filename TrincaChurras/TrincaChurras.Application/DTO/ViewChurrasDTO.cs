using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrincaChurras.Application.DTO
{
    public class ViewChurrasDTO
    {
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public string Razao { get; set; }
        public List<ViewParticipanteDTO> Participantes { get; set; }
    }

    public class ViewParticipanteDTO
    {
        public string Nome { get; set; }
        public bool Aceitou { get; set; }
    }
}
