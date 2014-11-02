using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects.Estructura
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Estructura
    {
        [JsonProperty]
        public string header { get; set;}

        [JsonProperty]
        public List<Campo> campos{ get; set;}

        [JsonProperty]
        public string footer { get; set; }

        public Estructura()
        {
            campos = new List<Campo>();
        }
    }
}
