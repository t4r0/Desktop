using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    public class Grupo : ResourceObject<Grupo>
    {
        [JsonProperty]
        public String name { get; set; }

        public Grupo(): base("/api/v1/grupos/")
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
                    Error.ingresarError(3, "No se ha guardado la Informacion en la base de datos "+e.Message);
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
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos "+e.Message);
                }
            }
        }

        /*FUNCIONES ESCENCIALES*/

        public ArrayList regresarTodos()
        {
            List<Grupo> lista = null;
            try
            {
                lista = this.fetchAll();
                if (lista == null)
                    Error.ingresarError(2, "No se econtro ninguna Ficha registrada " );
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet "+e.Message);
            }

            return new ArrayList(lista);
        }

        public void regresarObjeto(string resourceUring)
        {
            try
            {
                Grupo grupo = new Grupo();
                grupo.resource_uri = resourceUring;
                grupo = grupo.Get();
                if (grupo == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.name = grupo.name;
                this.id = grupo.id;
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
        }

        public void regresarObjeto()
        {
            regresarObjeto(this.resource_uri);
        }

        public static void asignarUsuarios(string username, int grupo)
        {
            try
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                dict["username"] = username;
                dict["id"] = grupo.ToString();
                string content = JsonConvert.SerializeObject(dict, Formatting.Indented);
                Connector conector = new Connector("/api/v1/grupos/registrar/");
                conector.create(content);
            }
            catch (Exception e)
            {
                Error.ingresarError(3, "No se ha asigando correctamente la relacion de grupo " + e.Message);
            }

        }
    }
}
