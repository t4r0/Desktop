using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    public class Traslado : ResourceObject<Traslado>
    {
         public Traslado():base("v1/fichas/")
        {

        }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public Boolean bodega { get; set; }

        [JsonProperty]
        public string nombre { get; set; }
    }
}
