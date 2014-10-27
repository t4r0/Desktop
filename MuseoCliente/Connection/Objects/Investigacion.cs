using System;
using System.Collections;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Investigacion : ResourceObject<Investigacion>
    {
        public Investigacion()
            : base( "/api/v1/investigaciones/" )
        {

        }

        [JsonProperty]
        public string editor { get; set; }

        [JsonProperty]
        public string titulo { get; set; }

        [JsonProperty]
        public string contenido { get; set; }

        [JsonProperty]
        public string resumen { get; set; }

        [JsonProperty]
        public string autor { get; set; }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public Boolean publicado { get; set; }


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
                    string error = e.Source; // para ver el nombre del error.
                    Error.ingresarError( 3, "No se ha guardado en la Informacion en la base de datos" );
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
                    string error = e.Source;// para ver el nombre del error
                    Error.ingresarError( 3, "No se ha modifico en la Informacion en la base de datos" );
                }
            }
        }


        public ArrayList consultaArtitulo( String titulo )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?titulo=" + titulo ) );
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

        public ArrayList consultaAutor( String autor )
        {
            ArrayList listaNueva = null;

            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?autor" + autor ) );
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

        public ArrayList regresarLinkInvestigacion()
        {
            ArrayList listaNueva = null;
            try
            {
                LinkInvestigacion LinkInvestigacion = new LinkInvestigacion();
                listaNueva = new ArrayList( LinkInvestigacion.GetAsCollection( LinkInvestigacion.resource_uri + "?investigacion=" + this.id ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias" );
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
            Investigacion Temp = this.Get( id.ToString() );
            if( Temp == null )
            {
                Error.ingresarError( 2, "No se encontro coincidencia" );
                return;
            }
            this.autor = Temp.autor;
            this.contenido = Temp.contenido;
            this.editor = Temp.editor;
            this.fecha = Temp.fecha;
            this.publicado = Temp.publicado;
            this.resumen = Temp.resumen;
            this.titulo = Temp.titulo;
        }

    }
}
