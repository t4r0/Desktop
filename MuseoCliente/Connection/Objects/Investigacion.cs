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
    public class Investigacion : ResourceObject<Investigacion>
    {
        public Investigacion():base("v1/categoria/")
        {

        }

        [JsonProperty]
        public string editor { get; set; }
       
        [JsonProperty]
        public string titulo { get; set; }

        [JsonProperty]
        public string contenido { get; set; }

        [JsonProperty]
        public string resumen { get; set; }

        [JsonProperty]
        public string autor { get; set; }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public Boolean publicado { get; set; }


        
    }
}
