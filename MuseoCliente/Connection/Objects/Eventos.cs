using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Eventos:ResourceObject<Eventos>
    {
        [JsonProperty]
        public String  nombre { get; set; }
        [JsonProperty]
        public String descripcion { get; set; }
        [JsonProperty]
        public String afiche { get; set; }
        [JsonProperty]
        public DateTime fecha { get; set; }
        [JsonProperty]
        public int sala { get; set; }
        [JsonProperty]
        public int usuario { get; set; }

        public Eventos():base("asld/asl/asd")
        {

        }
    }
}
