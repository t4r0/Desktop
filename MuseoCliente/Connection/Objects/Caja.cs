using System;
using System.Collections;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace MuseoCliente.Connection.Objects
{
    public class Caja : ResourceObject<Caja>
    {
        [JsonProperty]
        public string codigo { get; set; }

        public Caja()
            : base( "/api/v1/cajas/" )
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

        public ArrayList consultarCodigo( string codigo )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( "?codigo=" + codigo ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro codigo similar" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarTraslado()
        {
            ArrayList listaNueva = null;
            try
            {
                Traslado Traslado = new Traslado();
                listaNueva = new ArrayList( Traslado.GetAsCollection( Traslado.resource_uri + "?caja__contains=" + this.id ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarTodo()
        {
            List<Caja> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection();
                if (listaNueva == null)
                    Error.ingresarError(2, "No se econtro ninguna Caja registrada");
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "tabla vacia" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public void regresarObjecto( int id )
        {
            this.resource_uri = this.resource_uri + id + "/";
            Caja Temp = this.Get();
            if( Temp == null )
            {
                Error.ingresarError( 2, "No se encontro coincidencia" );
                return;
            }
            this.id = Temp.id;
            this.codigo = Temp.codigo;
            this.resource_uri = Temp.resource_uri;
        }
    }
}
