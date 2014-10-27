using System;
using System.Collections;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Usuario : ResourceObject<Usuario>
    {
        public Usuario()
            : base( "/api/v1/usuarios/" )
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
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public void regresarObjecto( string userName )
        {
            Usuario Temp = this.Get( userName );
            if( Temp == null )
            {
                Error.ingresarError( 2, "No se encontro coincidencia" );
                return;
            }
            this.email = Temp.email;
            this.first_name = Temp.first_name;
            this.is_active = Temp.is_active;
            this.is_staff = Temp.is_staff;
            this.is_superuser = Temp.is_superuser;
            this.last_login = Temp.last_login;
            this.last_name = Temp.last_name;
            this.password = Temp.password;
            this.username = Temp.username;
        }
    }
}




