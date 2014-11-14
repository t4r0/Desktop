using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
namespace MuseoCliente.Connection.Objects
{
    public class Eventos : ResourceObject<Eventos>
    {
        [JsonProperty]
        public String afiche { get; set; }
        [JsonProperty]
        public String descripcion { get; set; }
        [JsonProperty]
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime fecha { get; set; }
        [JsonProperty]
        public string fotoSala { get; set; }
        [JsonProperty]
        public string hora { get; set; }
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public string sala { get; set; }
        [JsonProperty]
        public string usuario { get; set; }

        public Eventos()
            : base( "/api/v1/eventos/" )
        {
            fecha = DateTime.Today;
        }

        public bool ShouldSerializefotoSala()
        {
            return false;
        }

        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch( Exception e )
            {
                Error.ingresarError( 3, "No se ha guardado en la Informacion en la base de datos " );
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

        public ArrayList consultarNombre( string nombre )  //  la acabo de agregar segun la clase fichas 
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultarNombre = "?nombre__icontains=" + nombre +"&fecha__gte=" + DateTime.Today;
                listaNueva = this.GetAsCollection( consultarNombre );

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia con el nombre" );
                return null;
            }

            return new ArrayList( listaNueva );
        }

        public ArrayList consultardescripcion( string descripcion )  //  la acabo de agregar segun la clase fichas  segunda agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultardescripcion = "?descripcion=" + descripcion;
                listaNueva = this.GetAsCollection( consultardescripcion );

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia con la descripcion" );
                return null;
            }

            return new ArrayList( listaNueva );
        }

        public ArrayList consultarafiche( string afiche )  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultarafiche =  "?afiche=" + afiche;
                listaNueva = this.GetAsCollection( consultarafiche );

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia con el afiche" );
                return null;
            }

            return new ArrayList( listaNueva );
        }


        public ArrayList consultaraficheporfecha( DateTime fecha )  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {

                string fecha2 = fecha.Date.ToString();
                string consultaraficheporfecha =  "?fecha2=" + fecha2;
                listaNueva = this.GetAsCollection( consultaraficheporfecha );


            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia con la fecha" );
                return null;
            }
            return new ArrayList( listaNueva );
        }


        public ArrayList consultaraficheporsala( int sala )  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {

                string sala2 = sala.ToString();
                //fecha.Date.ToString();
                string consultaraficheporsala ="?sala=" + sala2;
                listaNueva = this.GetAsCollection( consultaraficheporsala );

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia con la sala" );
                return null;
            }
            return new ArrayList( listaNueva );
        }


        public ArrayList consultareventoporusuario( int usuario )  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {

                string usuario2 = usuario.ToString();
                //fecha.Date.ToString();
                string consultareventoporusuario =  "?usuario=" + usuario2;
                listaNueva = this.GetAsCollection( consultareventoporusuario );


            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia con el usuario" );
                return null;
            }

            return new ArrayList( listaNueva );
        }


        public void regresarObjeto( int id )
        {
            try
            {
                this.resource_uri = this.resource_uri + id + "/";
                Eventos eventosTemp = this.Get();
                if( eventosTemp == null )
                {
                    Error.ingresarError( 2, "Este Objeto no existe porfavor, ingresar correcta la busqueda" );
                    return;
                }
                this.id = eventosTemp.id;
                this.nombre = eventosTemp.nombre;
                this.descripcion = eventosTemp.descripcion;
                this.afiche = eventosTemp.afiche;
                this.fecha = eventosTemp.fecha;
                this.sala = eventosTemp.sala;
                this.usuario = eventosTemp.usuario;
                this.resource_uri = eventosTemp.resource_uri;
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
        }

        public void regresarObjeto()
        {
            regresarObjeto( this.id );
        }


        public ArrayList regresarTodos()
        {
            ArrayList listaNueva = null;
            try
            {

                List<Eventos> todoseventos = this.GetAsCollection();

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna al parecer la tabla esta vacia" );
                return null;
            }

            return new ArrayList( listaNueva );
        }

        public ArrayList regresarEventos()
        {
            List<Eventos> listaNueva = null;
            try
            {
                Eventos clas = new Eventos();
                string consulta =  "?eventos=" + this.id.ToString();
                listaNueva = clas.GetAsCollection( consulta );

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia " );
                return null;
            }

            return new ArrayList( listaNueva );
        }

        public ArrayList regresarEventosProximos()
        {
            List<Eventos> listaNueva = null;
            try
            {
                List<Eventos> Temp = this.fetchAll();
                listaNueva = new List<Eventos>();
                foreach( Eventos Evento in Temp )
                {
                    if( Evento.fecha >= DateTime.Now )
                    {
                        listaNueva.Add( Evento );
                    }
                }
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null)
            {
                Error.ingresarError( 2, "No se encontro ninguna coincidencia " );
                return null;
            }

            return new ArrayList( listaNueva );
        }

        public ArrayList regresarEventosFinalizados()
        {
            List<Eventos> listaNueva = null;
            try
            {
                List<Eventos> Temp = this.fetchAll();
                listaNueva = new List<Eventos>();
                if(Temp != null)
                foreach( Eventos Evento in Temp )
                {
                    if( Evento.fecha < DateTime.Now )
                    {
                        listaNueva.Add( Evento );
                    }
                }
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }

            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No hay eventos finalizados " );
                return null;
            }

            return new ArrayList( listaNueva );
        }
    }
}
