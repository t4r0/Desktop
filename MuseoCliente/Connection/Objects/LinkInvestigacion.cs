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
    public class LinkInvestigacion:ResourceObject<LinkInvestigacion>
    {
        public LinkInvestigacion():base("v1/categoria/")
        {

        }
        
        [JsonProperty]
        public string link { get; set; }
    }
}
