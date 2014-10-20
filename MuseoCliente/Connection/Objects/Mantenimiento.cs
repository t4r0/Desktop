using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Mantenimiento:ResourceObject<Mantenimiento>
    {
        [JsonProperty]
        public int procedimiento { get; set; }
        [JsonProperty]
        public String metodoMaterial { get; set; }
        [JsonProperty]
        public DateTime fecha { get; set; }
        [JsonProperty]
        public int consolidacion { get; set; }

        public Mantenimiento()
            : base("/v1/mantenimiento/")
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

        public ArrayList consultarNombre(int consolidacion)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                ICollection<Mantenimiento> todasMantenimiento = (ICollection<Mantenimiento>)this.GetAsCollection();
                var mantenimientoConsolidacion = from mantenimeinto in todasMantenimiento
                                                 where mantenimeinto.consolidacion == consolidacion
                                                 select mantenimeinto;
                listaNueva.AddRange((ICollection)mantenimientoConsolidacion);

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
