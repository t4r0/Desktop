using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Categoria : ResourceObject<Categoria>
    {
        [JsonProperty]
        public string nombre { get; set; }

        public Categoria()
            : base( "/v1/categorias/" )
        {

        }

        public void guardar()
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

        public void modificar()
        {
            try
            {
                this.Save( this.id.ToString() );
            }
            catch( Exception e )
            {
                Error.ingresarError( 4, "No se ha modifico en la Informacion en la base de datos" );
            }
        }


        public ArrayList consultarNombre( String nombre )
        {
            ArrayList listaNueva = null;

            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?nombre=" + nombre ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }

            return listaNueva;
        }

        public ArrayList regresarClasificacion()
        {
            ArrayList listaNueva = null;
            try
            {
                Clasificacion Clasificacion = new Clasificacion();
                List<Clasificacion> Clasificaciones = Clasificacion.GetAsCollection( Clasificacion.resource_uri + "?categoria=" + this.id );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron clasificaciones para esta categoria" );
            }
            return listaNueva;
        }

        public ArrayList regresarTodo()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "tabla vacia" );
            }
            return listaNueva;
        }
    }
}
