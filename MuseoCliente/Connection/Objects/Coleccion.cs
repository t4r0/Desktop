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
            : base("/api/v1/colecciones/")
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
            List<Coleccion> listaNueva = null;
            try
            {
                string consultarNombre = "?nombre_icontains=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron Colecciones del con el nombre: "+nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public void regresarObjeto(int id)//2
        {
            try
            {
                this.resource_uri = this.resource_uri + id + "/";
                Coleccion fichaTemp = this.Get();
                if (fichaTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = fichaTemp.id;
                this.nombre = fichaTemp.nombre;
                this.resource_uri = fichaTemp.resource_uri;
                

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
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron Clasificaciones de la Clasificacion: "+this.nombre);
                return null;
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarTodo()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList(this.fetchAll());
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "tabla vacia");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Colecciones en la Base de Datos");
                return null;
            }
            return listaNueva;
        }

        public List<Categoria> ObtenerCategorias()
        {
            try
            {
                Categoria cats = new Categoria();
                string newUri = conector.BaseUri;
                conector.BaseUri = "/api/v1/categorias/";
                string content = conector.fetch("?coleccion=" + this.id.ToString());
                conector.BaseUri = conector.BaseUri;
                return cats.DeserializeList(content);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, e.Message);
            }
            return null;
        }
    }
}