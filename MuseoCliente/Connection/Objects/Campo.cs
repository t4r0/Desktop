using System;
using System.Collections;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Campo : ResourceObject<Campo>
    {
        public Campo()
            : base( "/api/v1/categoria/" )
        {

        }

        [JsonProperty]
        public int campoEstructura { get; set; }

        [JsonProperty]
        public int tipoCampo { get; set; }

        [JsonProperty]
        public string valorTexto { get; set; }

        [JsonProperty]
        public string valorTextoLargo { get; set; }

        [JsonProperty]
        public DateTime valorFecha { get; set; }

        [JsonProperty]
        public float valorNumerico { get; set; }

        [JsonProperty]
        public int valorRadio { get; set; }

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

        public ArrayList consultarTipoCampo( int tipoCampo )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?tipocampo__contains=" + tipoCampo ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con tipo de campo: " + tipoCampo );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList consultarCampoEstructura( int campoEstructura )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?campoestructura__contains=" + campoEstructura ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con campoEstructura: " + campoEstructura );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList consultarValorTexto( string valorTexto )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?valortexto__contains=" + valorTexto ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con valorTexto: " + valorTexto );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList consultarValorTextoLargo( string valorTextoLargo )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?valortextolargo__contains=" + valorTextoLargo ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con valorTextoLargo: " + valorTextoLargo );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList consultarValorFecha( DateTime valorFecha )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?valorfecha__contains=" + valorFecha ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con fecha: " + valorFecha.Date );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList consultarValorNumerico( float valorNumerico )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?valornumerico__contains=" + valorNumerico ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con valorNumerico: " + valorNumerico );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList consultarValorRadio( int valorRadio )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( this.resource_uri + "?valorradio__contains=" + valorRadio ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con valorRadio: " + valorRadio );
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
            Campo Temp = this.Get( id.ToString() );
            if( Temp == null )
            {
                Error.ingresarError( 2, "No se encontro coincidencia" );
                return;
            }
            this.campoEstructura = Temp.campoEstructura;
            this.tipoCampo = Temp.tipoCampo;
            this.valorFecha = Temp.valorFecha;
            this.valorNumerico = Temp.valorNumerico;
            this.valorRadio = Temp.valorRadio;
            this.valorTexto = Temp.valorTexto;
            this.valorTextoLargo = Temp.valorTextoLargo;
        }
    }
}
