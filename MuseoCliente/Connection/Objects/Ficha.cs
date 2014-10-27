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
            : base("/api/v1/fichas/")
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

        public void modificar()
        {
            try
            {
                this.Save(this.id.ToString());
            }
            catch (Exception e)
            {
                Error.ingresarError(4, "No se ha modifico en la Informacion en la base de datos");
            }
        }

        public ArrayList consultarNombre(string nombre)//1
        {
            List<Ficha> listaNueva = null;
            try
            {
                string consultarNombre = this.resource_uri+"?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro Clasi");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro Fichas con el nombre: "+nombre);
                return null;
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList consultarConsolidacion(bool consolidacion)
        {
            List<Ficha> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?consolidacion=" + consolidacion.ToString();
                listaNueva = this.GetAsCollection(consultar);               
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron Fichas con Consolidacion: "+consolidacion);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public void regresarObjeto(int id)//2
        {
            try
            {
                Ficha fichaTemp = this.Get(id.ToString());
                if (fichaTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = fichaTemp.id;
                this.nombre = fichaTemp.nombre;
                this.estructura = fichaTemp.estructura;
                this.consolidacion = fichaTemp.consolidacion;
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
        }

        public void regresarObjeto()//3
        {
            regresarObjeto(this.id);
        }

        public ArrayList regresarTodos()
        {
            List<Ficha> todasFichas = null;
            try
            {

                 todasFichas = this.GetAsCollection();

                if (todasFichas == null)
                    Error.ingresarError(2, "No se econtro ninguna Ficha registrada");
            }
            catch (Exception e)
            {
                 Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (todasFichas == null)
            {
                Error.ingresarError(2, "No Existen Fichas");
                return null;
            }
            return new ArrayList(todasFichas);
        }

        public ArrayList regresarClasificaciones()//4
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                Clasificacion clas = new Clasificacion();
                string consulta = clas.resource_uri+"?ficha=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron Clasificaciones con la Ficha: "+this.nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }
        
    }
}
