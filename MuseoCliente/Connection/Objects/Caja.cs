using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Caja : ResourceObject<Caja>
    {
        [JsonProperty]
        public String codigo { get; set; }

        public Caja()
            : base( "v1/cajas/" )
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
                if( e.Source != null )
                {
                    Error.ingresarError( 3, "No se ha guardado la Informacion en la base de datos" );
                }
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
                if( e.Source != null )
                {
                    Error.ingresarError( 4, "No se ha modificado la Informacion en la base de datos" );
                }
            }
        }

        public ArrayList consultarNombre( string codigo )
        {
            List<Caja> listaNueva = new List<Caja>();
            try
            {
                listaNueva = this.GetAsCollection( this.resource_uri + "?codigo=" + codigo );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro codigo similar" );
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList regresarTraslado()
        {
            ArrayList listaNueva = null;
            try
            {
                Traslado Traslado = new Traslado();
                listaNueva = new ArrayList( Traslado.GetAsCollection( Traslado.resource_uri + "?caja=" + this.id ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
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
