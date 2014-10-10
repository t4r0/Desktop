using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Vitrina:ResourceObject<Vitrina>
    {
        [JsonProperty]
        public String numero { get; set; }
        [JsonProperty]
        public int sala { get; set; }

        public Vitrina()
            : base("/asdf")
        {
        }
    }
}
