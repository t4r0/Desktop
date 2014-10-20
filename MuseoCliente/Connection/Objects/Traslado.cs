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
        public Traslado()
            : base("v1/fichas/")
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
                    Error.ingresarError(3, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

        public ArrayList listarBodegas()
        {
            ArrayList lista = null;
            ArrayList listaNueva = null;
            try
            {
                foreach (Traslado traslado in lista)
                {
                    if (traslado.bodega)
                    {
                        listaNueva.Add(traslado);
                    }
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontraron bodegas");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontraron bodegas");
            }
            return listaNueva;
        }

        // hace las consultas solo por fecha sin incluir tiempo
        public ArrayList consultarFecha(DateTime Fecha)
        {
            ArrayList lista = null;
            ArrayList listaNueva = null;
            try
            {
                lista = this.GetAsCollection();
                foreach (Traslado traslado in lista)
                {
                    if (traslado.fecha.Date == fecha.Date)
                    {
                        listaNueva.Add(traslado);
                    }
                }
                if (listaNueva == null)
                {
                    Error.ingresarError(2, "no se encontraron coincidencias para la fecha: " + Fecha);
                }
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias para la fecha: " + Fecha);
            }
            return listaNueva;
        }

        public ArrayList consultarNombre(string Nombre)
        {
            ArrayList lista = null;
            ArrayList listaNueva = null;
            try
            {
                lista = this.GetAsCollection();
                foreach (Traslado traslado in lista)
                {
                    if (traslado.nombre == Nombre)
                    {
                        listaNueva.Add(traslado);
                    }
                }
                if (listaNueva == null)
                {
                    Error.ingresarError(2, "no se encontraron Traslados con el nombre: " + Nombre);
                }
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron Traslados con el nombre: " + Nombre);
            }
            return listaNueva;
        }
    }
}
