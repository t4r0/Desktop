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
    class Consolidacion:ResourceObject<Consolidacion>
    {
        [JsonProperty]
        public Boolean limpieza { get; set; }
        [JsonProperty]
        public DateTime fechaInicio { get; set; }
        [JsonProperty]
        public DateTime fechaFinal { get; set; }
        [JsonProperty]
        public int responsable { get; set; }
        [JsonProperty]
        public int codigoPieza { get; set; }

        public Consolidacion()
            : base("/v1/consolidacion/")
        {
        }

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

        public ArrayList consultarConsolidacion(String dia)
        {
            List<Consolidacion> listaNueva = new List<Consolidacion>();
            try
            {

                List<Consolidacion> todoConsolidacion = this.GetAsCollection();
                foreach (Consolidacion hol in todoConsolidacion)
                {
                    //if (hol.fechaInicio .Contains(dia))
                     //   listaNueva.Add(hol);
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
