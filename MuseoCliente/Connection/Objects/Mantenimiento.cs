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
            ArrayList listaNueva = null;
            try
            {
                ICollection<Mantenimiento> lista = (ICollection<Mantenimiento>)this.GetAsCollection();
                var Mantenimientos = from mantenimiento in lista where mantenimiento.procedimiento == procedimiento select mantenimiento;
                listaNueva.AddRange((ICollection)Mantenimientos);
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
            ArrayList listaNueva = null;
            try
            {
                ICollection<Mantenimiento> lista = (ICollection<Mantenimiento>)this.GetAsCollection();
                var Mantenimientos = from mantenimiento in lista where mantenimiento.metodoMaterial == metodoMaterial select mantenimiento;
                listaNueva.AddRange((ICollection)Mantenimientos);
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
            ArrayList listaNueva = null;
            try
            {
                ICollection<Mantenimiento> lista = (ICollection<Mantenimiento>)this.GetAsCollection();
                var Mantenimientos = from mantenimiento in lista where mantenimiento.fecha.Date == fecha.Date select mantenimiento;
                listaNueva.AddRange((ICollection)Mantenimientos);
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
            ArrayList listaNueva = null;
            try
            {
                ICollection<Mantenimiento> lista = (ICollection<Mantenimiento>)this.GetAsCollection();
                var Mantenimientos = from mantenimiento in lista where mantenimiento.consolidacion == consolidacion select mantenimiento;
                listaNueva.AddRange((ICollection)Mantenimientos);
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
