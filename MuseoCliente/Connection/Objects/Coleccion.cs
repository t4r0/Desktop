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
    public class Coleccion : ResourceObject<Coleccion>
    {
        [JsonProperty]
        public string nombre { get; set; }

        public Coleccion()
            : base("/v1/colecciones/")
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

                Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos"+ e.Message.ToString());
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

        public ArrayList consultarNombre(string nombre)//1
        {
            List<Coleccion> listaNueva = null;
            try
            {
                string consultarNombre = "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public void regresarObjeto(int id)//2
        {
            try
            {
                Coleccion fichaTemp = this.Get(id.ToString());
                if (fichaTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = fichaTemp.id;
                this.nombre = fichaTemp.nombre;
                

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

        public ArrayList regresarClasificacion()//4
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                Clasificacion clas = new Clasificacion();
                string consulta = "?coleccion=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarTodo()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList(this.GetAsCollection());
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "tabla vacia");
            }
            return listaNueva;
        }
    }
}