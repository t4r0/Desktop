using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Mantenimiento:ResourceObject<Mantenimiento>
    {
        [JsonProperty]
        public int procedimiento { get; set; }
        [JsonProperty]
        public String metodoMaterial { get; set; }
        [JsonProperty]
        public DateTime fecha { get; set; }
        [JsonProperty]
        public int consolidacion { get; set; }

        public Mantenimiento()
            : base("kas/asjd/las")
        {
        }
    }
}
