using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Autor : ResourceObject<Autor>
    {
        [JsonProperty]
        public string pais { get; set; }
        [JsonProperty]
        public string nombre { get; set; }
        [JsonProperty]
        public string apellido { get; set; }

        public Autor() : base( "/api/v1/autores/" )
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
                Error.ingresarError(e.Message);
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
                Error.ingresarError(e.Message);
            }
        }

        public ArrayList consultarNombre( String nombre )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection(  "?nombre__contains=" + nombre ) );
            }
            catch( Exception e )
            {
                Error.ingresarError(e.Message);
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
                listaNueva = new ArrayList( this.GetAsCollection( "?apellido__contains=" + apellido ) );
            }
            catch( Exception e )
            {
                Error.ingresarError(e.Message);
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
                List<Pieza> Piezas = Pieza.GetAsCollection( "?autor__contains=" + this.id );
                listaNueva = new ArrayList( Piezas );
            }
            catch( Exception e )
            {
                Error.ingresarError(e.Message);
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
                List<Investigacion> Investigaciones = Investigacion.GetAsCollection( "?autor__contains=" + this.id );
                listaNueva = new ArrayList( Investigaciones );
            }
            catch( Exception e )
            {
                Error.ingresarError(e.Message);
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
            List<Autor> listaNueva = null;
            try
            {
                listaNueva = this.fetchAll();
            }
            catch( Exception e )
            {
                Error.ingresarError(e.Message);
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public void regresarObjeto( int id )
        {
            try
            {

                this.resource_uri = this.resource_uri + id + "/";
                Autor Temp = this.Get();
                if (Temp == null)
                {
                    Error.ingresarError(2, "No se encontro coincidencia");
                    return;
                }
                this.id = Temp.id;
                this.nombre = Temp.nombre;
                this.apellido = Temp.apellido;
                this.pais = Temp.pais;
                this.resource_uri = Temp.resource_uri;
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
            }
        }
    }
}
