using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Autor:ResourceObject<Autor>
    {
        [JsonProperty]
        public int pais { get; set; }
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public String apellido { get; set; }

        public Autor()
            : base("/v1/autores/")
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

                List<Autor> todasAutor = this.GetAsCollection();
                foreach (Autor hol in todasAutor)
                {
                    if (hol.nombre.Contains(nombre))
                        listaNueva.Add(hol);
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

        public ArrayList consultarApellido(String apellido)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Autor> todasAutor = this.GetAsCollection();
                foreach (Autor hol in todasAutor)
                {
                    if (hol.apellido.Contains(apellido))
                        listaNueva.Add(hol);
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
