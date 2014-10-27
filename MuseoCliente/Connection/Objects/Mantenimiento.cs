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
            : base("/api/v1/mantenimiento/")
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

        public void modificar()
        {
            try
            {
                this.Save(this.id.ToString());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

        /*CONSULTAS*/

        public ArrayList regresarTodos()
        {
            List<Mantenimiento> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection();
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Mantenimeintos en la base de Datos");
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public void regresarObjeto(int id)
        {
            try
            {
                Mantenimiento fichaTemp = this.Get(id.ToString());
                if (fichaTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = fichaTemp.id;
                this.procedimiento = fichaTemp.procedimiento;
                this.metodoMaterial = fichaTemp.metodoMaterial;
                this.fecha = fichaTemp.fecha;
                this.consolidacion = fichaTemp.consolidacion;
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
        }

        public void regresarObjeto()
        {
            regresarObjeto(this.id);
        }

        public ArrayList consultarProcedimiento(int procedimiento)
        {
            List<Mantenimiento> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?procedimiento=" + procedimiento.ToString();
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con procedimiento: " + procedimiento);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con procedimiento: " + procedimiento);
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Mantenimiento con el procedimiento asiganado");
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarMetodoMaterial(string metodoMaterial)
        {
            List<Mantenimiento> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?metodoMaterial=" + metodoMaterial;
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con metodoMaterial: " + metodoMaterial);
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se Mantenimientos con el metodo de Material: "+metodoMaterial);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarFecha(DateTime fecha)
        {
            List<Mantenimiento> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?fecha=" + fecha.Date.ToString();
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con fecha: " + fecha.Date);
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraon Mantenimeitnos con la fecha: "+fecha.Date.ToString());
                return null;
            }
            return new ArrayList(listaNueva);
        }

        /*CLASE PADRE*/
        public Consolidacion consultarConsolidacion()
        {
            Consolidacion consol = new Consolidacion();
            try
            {
                consol.regresarObjeto(this.consolidacion);
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            return consol;
        }
    }
}
