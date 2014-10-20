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
    public class Investigacion : ResourceObject<Investigacion>
    {
        public Investigacion()
            : base("/v1/mantenimiento/")
        {

        }

        [JsonProperty]
        public string editor { get; set; }
       
        [JsonProperty]
        public string titulo { get; set; }

        [JsonProperty]
        public string contenido { get; set; }

        [JsonProperty]
        public string resumen { get; set; }

        [JsonProperty]
        public string autor { get; set; }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public Boolean publicado { get; set; }


        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    string error = e.Source; // para ver el nombre del error.
                    Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos");
                }
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
                if (e.Source != null)
                {
                    string error = e.Source;// para ver el nombre del error
                    Error.ingresarError(3, "No se ha modifico en la Informacion en la base de datos");
                }
            }
        }


        public ArrayList consultaArtitulo(String titulo)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {
                List<Investigacion> lista = this.GetAsCollection();
                foreach (Investigacion investigacion in lista)
                {
                    if (investigacion.titulo.Contains(titulo))
                        listaNueva.Add(investigacion);
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

        public ArrayList consultaAutor(String autor)
        {
            ArrayList listaNueva = new ArrayList();

            try
            {
                List<Investigacion> lista = this.GetAsCollection();
                foreach (Investigacion investigacion in lista)
                {
                    if (investigacion.autor.Contains(autor))
                        listaNueva.Add(investigacion);
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
