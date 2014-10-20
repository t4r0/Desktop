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
    public class Ficha:ResourceObject<Ficha>
    {
      

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public Estructura estructura { get; set; }

        [JsonProperty]
        public bool consolidacion{get; set;}

        public Ficha():base("v1/fichas/")
        {
            this.estructura = new Estructura();
           
        }        
    }
}
