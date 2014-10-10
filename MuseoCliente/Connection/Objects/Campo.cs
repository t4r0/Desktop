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
    public class Campo : ResourceObject<Campo>
    {
         public Campo():base("v1/categoria/")
        {

        }

         [JsonProperty]
         public int campoEstructura { get; set; }

         [JsonProperty]
         public int tipoCampo { get; set; }

         [JsonProperty]
         public string valorTexto { get; set; }

         [JsonProperty]
         public string valorTextoLargo { get; set; }

         [JsonProperty]
         public DateTime valorFecha { get; set; }

         [JsonProperty]
         public float valorNumerico { get; set; }

         [JsonProperty]
         public int valorRadio { get; set; }
    }
}
