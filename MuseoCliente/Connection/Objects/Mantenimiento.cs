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
            : base("v1/mantenimientos/")
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

        public ArrayList consultarProcedimiento(int procedimiento)
        {
            List<Mantenimiento> listaNueva = new List<Mantenimiento>();
            try
            {
                List<Mantenimiento> todasPiezas = this.GetAsCollection();
                foreach (Mantenimiento mantenimiento in todasPiezas)
                {
                    if (mantenimiento.procedimiento == procedimiento)
                        listaNueva.Add(mantenimiento);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con procedimiento: " + procedimiento);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con procedimiento: " + procedimiento);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarMetodoMaterial(string metodoMaterial)
        {
            List<Mantenimiento> listaNueva = new List<Mantenimiento>();
            try
            {
                List<Mantenimiento> todasPiezas = this.GetAsCollection();
                foreach (Mantenimiento mantenimiento in todasPiezas)
                {
                    if (mantenimiento.metodoMaterial.Contains(metodoMaterial))
                        listaNueva.Add(mantenimiento);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con metodoMaterial: " + metodoMaterial);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con metodoMaterial: " + metodoMaterial);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarFecha(DateTime fecha)
        {
            List<Mantenimiento> listaNueva = new List<Mantenimiento>();
            try
            {
                List<Mantenimiento> todasPiezas = this.GetAsCollection();
                foreach (Mantenimiento mantenimiento in todasPiezas)
                {
                    if (mantenimiento.fecha.Date == fecha.Date)
                        listaNueva.Add(mantenimiento);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con fecha: " + fecha.Date);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con fecha: " + fecha.Date);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarConsolidacion(int consolidacion)
        {
            List<Mantenimiento> listaNueva = new List<Mantenimiento>();
            try
            {
                List<Mantenimiento> todasPiezas = this.GetAsCollection();
                foreach (Mantenimiento mantenimiento in todasPiezas)
                {
                    if (mantenimiento.consolidacion == consolidacion)
                        listaNueva.Add(mantenimiento);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con consolidacion: " + consolidacion);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con consolidacion: " + consolidacion);
            }
            return new ArrayList(listaNueva);
        }
    }
}
