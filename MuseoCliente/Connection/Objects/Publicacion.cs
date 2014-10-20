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
    public class Publicacion : ResourceObject<Publicacion>
    {

        public Publicacion()
            : base("v1/publicacion/")
        {
            

        }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public string publicacion { get; set; }

        [JsonProperty]
        public string link { get; set; }

       
    }
}