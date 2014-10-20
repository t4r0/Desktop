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
    public class Registro : ResourceObject<Registro>
    {
         public Registro():base("v1/fichas/")
        {
           
        }  
        
        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public Boolean consolidacion { get; set; }
    }
}
