using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Caja:ResourceObject<Caja>
    {
        [JsonProperty]
        public String codigo { get; set; }

        public Caja()
            : base("sdg/asd")
        {
        }
    }
}
