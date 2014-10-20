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
    public class Usuario : ResourceObject<Usuario>
    {
        public Usuario()
            : base("/v1/usuarios/")
        {

        }

        [JsonProperty]
        public string password { get; set; }

        [JsonProperty]
        public DateTime last_login { get; set; }

        [JsonProperty]
        public int is_superuser { get; set; }

        [JsonProperty]
        public string username { get; set; }

        [JsonProperty]
        public string first_name { get; set; }

        [JsonProperty]
        public int last_name { get; set; }

        [JsonProperty]
        public string email { get; set; }

        [JsonProperty]
        public int is_staff { get; set; }

        [JsonProperty]
        public int is_active { get; set; }


        public void guardar() //Crea un usuario
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

        public void modificar(string id) //Modifica un usuario
        {
            try
            {
                this.Save(id);
            }
            catch (Exception e)
            {
                Error.ingresarError(4, "No se ha modifico en la Informacion en la base de datos");
            }
        }


        public ArrayList Usuarios() //Devuelve lista de todos los usuarios ingresados
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Usuario> todosUsuarios = this.GetAsCollection();
                foreach (Usuario hol in todosUsuarios)
                {
                    listaNueva.Add(hol);
                }

                if (listaNueva == null)
                    Error.ingresarError(2, "No hay paises existentes");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No hay paises existentes");
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList Usuarios(String nombre) //Devuelve lista de todos los usuarios ingresados
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Usuario> todosUsuarios = this.GetAsCollection();
                foreach (Usuario hol in todosUsuarios)
                {
                    if (hol.username.Contains(nombre))
                        listaNueva.Add(hol);
                }

                if (listaNueva == null)
                    Error.ingresarError(2, "No hay Usuarios existentes");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No hay Usuarios existentes");
            }

            return new ArrayList(listaNueva);
        }
    }
}




