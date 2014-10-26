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
            : base( "/v1/autores/" )
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

        public void modificar( string id )
        {
            try
            {
                this.Save( id );
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

                List<Autor> todasAutor = this.GetAsCollection();
                foreach( Autor hol in todasAutor )
                {
                    if( hol.nombre.Contains( nombre ) )
                        listaNueva.Add( hol );
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

        public ArrayList consultarApellido( String apellido )
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Autor> todasAutor = this.GetAsCollection();
                foreach( Autor hol in todasAutor )
                {
                    if( hol.apellido.Contains( apellido ) )
                        listaNueva.Add( hol );
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
            return listaNueva;
        }
    }
}
