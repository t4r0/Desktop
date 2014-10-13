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
    public class Coleccion : ResourceObject<Coleccion>
    {
        [JsonProperty]
        public string nombre { get; set; }

        public Coleccion():base("v1/categoria/")
        {

        }
    }
}