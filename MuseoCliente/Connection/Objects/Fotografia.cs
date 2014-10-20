using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Fotografia:ResourceObject<Fotografia>
    {
        [JsonProperty]
        public int mantenimiento { get; set; }
        [JsonProperty]
        public int pieza { get; set; }
        [JsonProperty]
        public Int16 tipo { get; set; }
        [JsonProperty]
        public String ruta { get; set; }
        [JsonProperty]
        public Boolean perfil { set; get; }

        public Fotografia()
            : base("asd/asd")
        {
        }
    }
}
