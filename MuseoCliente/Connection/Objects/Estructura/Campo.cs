using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace MuseoCliente.Connection.Objects.Estructura
{
    [JsonObject(MemberSerialization.OptIn)]
    public class Campo
    {
        public enum TiposDeCampo
        {
            Texto=0,
            TextoLargo=1,
            Fecha=2,
            Numerico = 3,
            OpcionesExclusivas=4,
            OpcionMultiple = 5
        };

        [JsonProperty]        
        public int id{get; set;}

        [JsonProperty]
        public string nombre{get; set;}

        [JsonProperty]
        public TiposDeCampo tipo{get; set;}
        
        [JsonProperty]
        public string descripcion{get; set;}

        [JsonProperty]
        public List<string> opciones{get; set;}

        public Campo()
        {
            tipo = TiposDeCampo.Texto;
            opciones = new List<string>();
        }
    }
}
