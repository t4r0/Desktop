using System;
using System.Collections;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Usuario : ResourceObject<Usuario>
    {
        public Usuario()
            : base( "/api/v1/registrar/" )
        {
        }

        [JsonProperty]
        public string biografia { get; set; }

        [JsonProperty]
        public DateTime date_joined { get; set; }

        [JsonProperty]
        public string filiacion { get; set; }

        [JsonProperty]
        public string username { get; set; }

        [JsonProperty]
        public string password { get; set; }

        [JsonProperty]
        public string first_name { get; set; }

        [JsonProperty]
        public string last_name { get; set; }

        [JsonProperty]
        public string email { get; set; }

        [JsonProperty]
        public bool is_staff { get; set; }

        [JsonProperty]
        public bool voluntario { get; set; }

        [JsonProperty]
        public string pais { get; set; }

        [JsonProperty]
        public string fotografia { get; set; }

        public void guardar() //Crea un usuario
        {
            try
            {
                this.Create();
            }
            catch( Exception e )
            {
                Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos");
                if(e.Message.Contains("1062"))
                    Error.ingresarError( 3, "No se puede ingresar el Usuario porque ya existe en la base de Datos" );
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
                listaNueva = new ArrayList( this.GetAsCollection() );
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

        public ArrayList consultaUserName( String userName )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( "?username__contains=" + userName ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList regresarVoluntarios()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?voluntario=true" ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList( listaNueva );
        }
    }
}




