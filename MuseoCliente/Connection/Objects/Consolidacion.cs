using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Consolidacion:ResourceObject<Consolidacion>
    {
        [JsonProperty]
        public Boolean limpieza { get; set; }
        [JsonProperty]
        public DateTime fechaIniciio { get; set; }
        [JsonProperty]
        public DateTime fechaFinal { get; set; }
        [JsonProperty]
        public int responsable { get; set; }
        [JsonProperty]
        public int codigoPieza { get; set; }

        public Consolidacion()
            : base("as/sd/s")
        {
        }
    }
}
