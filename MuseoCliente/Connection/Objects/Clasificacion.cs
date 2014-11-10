using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Clasificacion : ResourceObject<Clasificacion>
    {
        [JsonProperty]
        public string coleccion { get; set; }
        [JsonProperty]
        public string categoria { get; set; }
        [JsonProperty]
        public string ficha { get; set; }
        [JsonProperty]
        public string nombre { get; set; }
        [JsonProperty]
        public string codigo { get; set; }
        [JsonProperty]
        public int piezas { get; set; }

        public Clasificacion()
            : base( "/api/v1/clasificacion/" )
        {

        }

        public bool ShouldSerializepiezas()
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
                if( e.Source != null )
                {
                    Error.ingresarError( 3, "No se ha guardado la Informacion en la base de datos "+e.Message );
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
                    Error.ingresarError( 4, "No se ha modificado la Informacion en la base de datos "+e.Message );
                }
            }
        }


        public ArrayList regresarPieza()
        {
            ArrayList listaNueva = null;
            try
            {
                Pieza Pieza = new Pieza();
                List<Pieza> Piezas = Pieza.GetAsCollection( "?clasificacion=" + this.id );
                listaNueva = new ArrayList( Piezas );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron piezas de este autor" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro la busqueda" );
                return null;
            }

            return listaNueva;
        }

        public ArrayList consultarNombre( string nombre )//1
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                string consultarNombre = "?nombre__contains=" + nombre;
                listaNueva = this.GetAsCollection( consultarNombre );


                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro la busqueda" );
                return null;
            }


            return new ArrayList( listaNueva );
        }

        public void regresarObjeto( int id)//2
        {
            try
            {
                this.resource_uri = this.resource_uri +id+"/";
                Clasificacion fichaTemp = this.Get();
                if( fichaTemp == null )
                {
                    Error.ingresarError( 2, "Este Objeto no existe porfavor, ingresar correcta la busqueda" );
                    return;
                }
                this.id = fichaTemp.id;
                this.coleccion = fichaTemp.coleccion;
                this.categoria = fichaTemp.categoria;
                this.ficha = fichaTemp.ficha;
                this.nombre = fichaTemp.nombre;
                this.codigo = fichaTemp.codigo;
                this.resource_uri = fichaTemp.resource_uri;

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Por favor Verifique su coneccion a Internet "+ e.Message );
            }
        }

        public void regresarObjeto()//3
        {
            regresarObjeto( this.id);
        }

        public ArrayList regresarTodo()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.fetchAll() );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "tabla vacia" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontro la busqueda" );
                return null;
            }

            return listaNueva;
        }

        //Consultar Padre
        public Coleccion consultarColeccion( int idColeccion )
        {
            Coleccion clase = new Coleccion();
            try
            {
                clase.regresarObjeto( idColeccion );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con sala: " + coleccion );
            }
            return ( clase );
        }


        public Categoria consultarCategoria( int idCategoria )
        {
            Categoria clase = new Categoria();
            try
            {
                clase.regresarObjeto( idCategoria );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con sala: " + categoria );
            }
            return ( clase );
        }

        public Ficha consultarFicha( int idFicha )
        {
            Ficha clase = new Ficha();
            try
            {
                clase.regresarObjeto( idFicha );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con sala: " + ficha );
            }
            return ( clase );
        }

    }
}
