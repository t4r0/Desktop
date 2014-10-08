using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Clasificacion:ResourceObject<Clasificacion>
    {
        [JsonProperty]
        public int coleccion { get; set; }
        [JsonProperty]
        public int categoria { get; set; }
        [JsonProperty]
        public int ficha { get; set; }
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public String codigo { get; set; }

        public Clasificacion()
            : base("asd/asd")
        {

        }
    }
}
