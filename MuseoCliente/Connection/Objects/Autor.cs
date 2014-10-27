using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    class Autor : ResourceObject<Autor>
    {
        [JsonProperty]
        public string pais { get; set; }
        [JsonProperty]
        public string nombre { get; set; }
        [JsonProperty]
        public string apellido { get; set; }

        public Autor()
            : base( "/api/v1/autores/" )
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
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "Nose encontro el nombre =" + nombre );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList consultarApellido( String apellido )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?apellido" + apellido ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "Nose encontro el apellido =" + apellido );
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarPieza()
        {
            ArrayList listaNueva = null;
            try
            {
                Pieza Pieza = new Pieza();
                List<Pieza> Piezas = Pieza.GetAsCollection( Pieza.resource_uri + "?autor=" + this.id );
                listaNueva = new ArrayList( Piezas );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron piezas de este autor" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "la lista esta vacia" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarInvestigacion()
        {
            ArrayList listaNueva = null;
            try
            {
                Investigacion Investigacion = new Investigacion();
                List<Investigacion> Investigaciones = Investigacion.GetAsCollection( Investigacion.resource_uri + "?autor=" + this.id );
                listaNueva = new ArrayList( Investigaciones );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron investigacion de este autor" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarTodos()
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
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public void regresarObjecto( int id )
        {
            Autor Temp = this.Get( id.ToString() );
            if( Temp == null )
            {
                Error.ingresarError( 2, "No se encontro coincidencia" );
                return;
            }
            this.nombre = Temp.nombre;
            this.pais = Temp.pais;
        }
    }
}
