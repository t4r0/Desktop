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
    public class Categoria:ResourceObject<Categoria>
    {
        [JsonProperty]
        public string nombre { get; set; }

        public Categoria()
            : base("/v1/categorias/")
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


        public ArrayList consultarNombre(String nombre)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {
                var lista = this.GetAsCollection();
                foreach (Categoria categoria in lista)
                {
                    if (categoria.nombre.Contains(nombre))
                        listaNueva.Add(categoria);
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
