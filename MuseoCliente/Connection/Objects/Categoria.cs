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
    public class Categoria:ResourceObject<Categoria>
    {
        [JsonProperty]
        public string nombre { get; set; }

        public Categoria():base("v1/categoria/")
        {
            
        }   
    }
}
