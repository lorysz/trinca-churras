using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrincaChurras.Domain.Entities
{
    public class User
    {
        [JsonProperty(PropertyName = "Id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "Nome")]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "IsSocio")]
        public bool IsSocio { get; set; }

        [JsonProperty(PropertyName = "StreamId")]
        public string StreamId { get; set; }

        public User()
        {
            var newGuid = Guid.NewGuid().ToString();
            Id = newGuid;
            StreamId = newGuid;
        }
    }
}
