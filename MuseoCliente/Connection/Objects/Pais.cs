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
    public class Pais : ResourceObject<Pais>
    {
 
        public Pais()
            : base("/v1/paises/")
        {

        }

        [JsonProperty]
        public string name { get; set; }

        [JsonProperty]
        public string printable_name { get; set; }

        [JsonProperty]
        public string iso3 { get; set; }

        [JsonProperty]
        public int num_code { get; set; }


        public void guardar() //Crear un Usuario
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


        public void modificar(int id) //Modifica datos de un pais
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


        public ArrayList consultarPaises() //Devuelve lista de todos los paises ingresados
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                ICollection<Pais> todosPaises = (ICollection<Pais>)this.GetAsCollection();
                var paisNombre = from country in todosPaises
                                  select name;
                listaNueva.AddRange((ICollection)paisNombre);

                if (listaNueva == null)
                    Error.ingresarError(2, "No hay paises existentes");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No hay paises existentes");
            }

            return new ArrayList(listaNueva);
        }


    }
}