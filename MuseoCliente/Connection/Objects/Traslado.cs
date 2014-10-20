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
    public class Traslado : ResourceObject<Traslado>
    {
        public Traslado(): base("v1/traslado/")
        {

        }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public Boolean bodega { get; set; }

        [JsonProperty]
        public string nombre { get; set; }

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
                    Error.ingresarError(3, "No se ha guardado la Informacion en la base de datos");
                }
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
                if (e.Source != null)
                {
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

        public ArrayList consultarBodega()
        {
            List<Traslado> listaNueva = new List<Traslado>();
            try
            {
                List<Traslado> todasPiezas = this.GetAsCollection();
                foreach (Traslado traslado in todasPiezas)
                {
                    if (traslado.bodega)
                        listaNueva.Add(traslado);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontraron bodegas");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontraron bodegas");
            }
            return new ArrayList(listaNueva);
        }

        // hace las consultas solo por fecha sin incluir tiempo
        public ArrayList consultarFecha(DateTime Fecha)
        {
            List<Traslado> listaNueva = new List<Traslado>();
            try
            {
                List<Traslado> todasPiezas = this.GetAsCollection();
                foreach (Traslado traslado in todasPiezas)
                {
                    if (traslado.fecha.Date == Fecha.Date)
                        listaNueva.Add(traslado);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias para la fecha: " + Fecha);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias para la fecha: " + Fecha);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarNombre(string Nombre)
        {
            List<Traslado> listaNueva = new List<Traslado>();
            try
            {
                List<Traslado> todasPiezas = this.GetAsCollection();
                foreach (Traslado traslado in todasPiezas)
                {
                    if (traslado.nombre.Contains(Nombre))
                        listaNueva.Add(traslado);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con el nombre: " + Nombre);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con el nombre: " + Nombre);
            }
            return new ArrayList(listaNueva);
        }
    }
}
