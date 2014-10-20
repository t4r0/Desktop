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
    public class Ficha:ResourceObject<Ficha>
    {
      

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public Estructura estructura { get; set; }

        [JsonProperty]
        public bool consolidacion{get; set;}

        public Ficha()
            : base("/v1/fichas/")
        {
            this.estructura = new Estructura();
           
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

                List<Ficha> todasFichas = this.GetAsCollection();
                foreach (Ficha hol in todasFichas)
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

        public ArrayList consultarConsolidacion(bool consolidacion)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Ficha> todasFichas = this.GetAsCollection();
                foreach (Ficha hol in todasFichas)
                {
                    if (hol.consolidacion == consolidacion)
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
