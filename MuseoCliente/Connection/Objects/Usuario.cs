using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Usuario : ResourceObject<Usuario>
    {
        public Usuario()
            : base("/v1/usuarios/")
        {

        }

        [JsonProperty]
        public string password { get; set; }

        [JsonProperty]
        public DateTime last_login { get; set; }

        [JsonProperty]
        public int is_superuser { get; set; }

        [JsonProperty]
        public string username { get; set; }

        [JsonProperty]
        public string first_name { get; set; }

        [JsonProperty]
        public int last_name { get; set; }

        [JsonProperty]
        public string email { get; set; }

        [JsonProperty]
        public int is_staff { get; set; }

        [JsonProperty]
        public int is_active { get; set; }
    }
}



