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
    public class Publicacion : ResourceObject<Publicacion>
    {

        public Publicacion()
            : base("v1/publicacion/")
        {
            

        }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public string publicacion { get; set; }

        [JsonProperty]
        public string link { get; set; }


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

        public void modificar(string id)
        {
            try
            {
                this.Save(id);
            }
            catch (Exception e)
            {
                Error.ingresarError(4, "No se ha modifico en la Informacion en la base de datos");
            }
        }


        public ArrayList consultarNombre(String nombre)
        {
            ArrayList listaNueva = new ArrayList(); 
          
            try
            {

                ICollection<Publicacion> todasPublicaciones = (ICollection<Publicacion>)this.GetAsCollection();
                var publicacionNombre = from publicacion in todasPublicaciones 
                                  where publicacion.nombre.Contains(nombre)
                                  select nombre;
                listaNueva.AddRange((ICollection)publicacionNombre);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro publicacion");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro publicacion");
            }

            return new ArrayList(listaNueva);
        }

       
    }
}