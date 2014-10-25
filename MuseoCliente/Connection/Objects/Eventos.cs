using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Eventos:ResourceObject<Eventos>
    {
        [JsonProperty]
        public String  nombre { get; set; }
        [JsonProperty]
        public String descripcion { get; set; }
        [JsonProperty]
        public String afiche { get; set; }
        [JsonProperty]
        public DateTime fecha { get; set; }
        [JsonProperty]
        public int sala { get; set; }
        [JsonProperty]
        public int usuario { get; set; }

        public Eventos()
            : base("/v1/eventos/")
        {

        }

        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch (Exception e)
            {
                Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos");
            }
        }

        public void modificar(int id)
        {
            try
            {
                this.Save(id.ToString());
            }
            catch (Exception e)
            {
                Error.ingresarError(4, "No se ha modifico en la Informacion en la base de datos");
            }
        }



        public ArrayList consultarEvento(String nombrevento)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {
                var lista = this.GetAsCollection();
                foreach (Eventos evento in lista)
                {
                    if (evento.nombre.Contains(nombrevento))
                        listaNueva.Add(evento);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }

            return new ArrayList(listaNueva);
        }
    }
}
