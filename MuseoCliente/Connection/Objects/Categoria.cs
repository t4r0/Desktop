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

        public void modificar( int id )
        {
            try
            {
                this.Save( id.ToString() );
            }
            catch( Exception e )
            {
                Error.ingresarError( 4, "No se ha modifico en la Informacion en la base de datos" );
            }
        }


        public ArrayList consultarNombre( String nombre )
        {
            ArrayList listaNueva = new ArrayList();

            try
            {
                var lista = this.GetAsCollection();
                foreach( Categoria categoria in lista )
                {
                    if( categoria.nombre.Contains( nombre ) )
                        listaNueva.Add( categoria );
                }
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }

            return new ArrayList( listaNueva );
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
    }
}
