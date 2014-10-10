using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Autor:ResourceObject<Autor>
    {
        [JsonProperty]
        public int pais { get; set; }
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public String apellido { get; set; }

        public Autor()
            : base("lasd/as/sd")
        {
        }
    }
}
