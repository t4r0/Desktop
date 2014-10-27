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
    public class ValorCheck : ResourceObject<ValorCheck>
    {

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public Boolean seleccionado { get; set; }

        public ValorCheck()
            : base("/api/v1/fichas/")
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
            List<ValorCheck> listaNueva = null;
            try
            {
                string consultarNombre = this.resource_uri + "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            

            return new ArrayList(listaNueva);
        }


        public void regresarObjeto(int id)//2
        {
            try
            {
                ValorCheck valorTemp = this.Get(id.ToString());
                if (valorTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = valorTemp.id;
                this.nombre = valorTemp.nombre;
                this.seleccionado = valorTemp.seleccionado;
                

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
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }

            return listaNueva;
        }
    }
}
