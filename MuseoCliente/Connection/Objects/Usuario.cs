using System;
using System.Collections;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Usuario : ResourceObject<Usuario>
    {
        public Usuario()
            : base( "/v1/usuarios/" )
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
            catch( Exception e )
            {
                Error.ingresarError( 3, "No se ha guardado en la Informacion en la base de datos" );
            }
        }

        public void modificar() //Modifica un usuario
        {
            try
            {
                this.Save( this.username );
            }
            catch( Exception e )
            {
                Error.ingresarError( 4, "No se ha modifico en la Informacion en la base de datos" );
            }
        }


        public ArrayList regresarTodos() //Devuelve lista de todos los usuarios ingresados
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No hay paises existentes" );
            }

            return new ArrayList( listaNueva );
        }
    }
}




