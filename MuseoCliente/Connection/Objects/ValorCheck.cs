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
    public class ValorCheck : ResourceObject<ValorCheck>
    {
        public ValorCheck():base("v1/fichas/")
        {

        }

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public Boolean seleccionado { get; set; }
    }
}
