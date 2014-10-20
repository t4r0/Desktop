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
    public class Pais : ResourceObject<Pais>
    {
 
        public Pais()
            : base("/v1/paises/")
        {

        }

        [JsonProperty]
        public string name { get; set; }

        [JsonProperty]
        public string printable_name { get; set; }

        [JsonProperty]
        public string iso3 { get; set; }

        [JsonProperty]
        public int num_code { get; set; }
    }
}