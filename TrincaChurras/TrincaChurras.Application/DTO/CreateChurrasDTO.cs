using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrincaChurras.Application.DTO
{
    public class CreateChurrasDTO
    {
        public DateTime Data { get; set; }
        public string Razao { get; set; }
        public string IdUser { get; set; }
    }
}
