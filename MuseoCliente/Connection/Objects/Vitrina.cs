using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Vitrina : ResourceObject<Vitrina>
    {
        [JsonProperty]
        public String numero { get; set; }
        [JsonProperty]
        public int sala { get; set; }

        public Vitrina()
            : base( "/api/v1/vitrina/" )
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
                    Error.ingresarError( 3, "No se ha guardado la Informacion en la base de datos " + e.Message );
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

        /*FUNCIONES ESCENCIALES*/

        public ArrayList regresarTodos()
        {
            List<Vitrina> lista = null;
            try
            {
                lista = this.GetAsCollection();
                if( lista == null )
                    Error.ingresarError( 2, "No se econtro ninguna Ficha registrada" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
            if( lista == null )
            {
                Error.ingresarError( 2, "No existen en la Base de Datos" );
                return null;
            }
            return new ArrayList( lista );
        }

        public void regresarObjeto( int id )
        {
            try
            {
                this.resource_uri = this.resource_uri + id + "/";
                Vitrina vitrina = this.Get();
                if( vitrina == null )
                {
                    Error.ingresarError( 2, "Este Objeto no existe porfavor, ingresar correcta la busqueda" );
                    return;
                }
                this.id = vitrina.id;
                this.numero = vitrina.numero;
                this.sala = vitrina.sala;
                this.resource_uri = vitrina.resource_uri;
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
        }

        //Funcion hecha por Miguel ... NO BORRAR!!!!!!!!
        public ArrayList regresarPorSala(int idS)
        {
            List<Vitrina> vitrinas = null;
            try
            {
                Vitrina clas = new Vitrina();
                string consulta = "?sala=" + idS;
                vitrinas = clas.GetAsCollection(consulta);
                if (vitrinas == null)
                    Error.ingresarError(2, "No se encontraron vitrinas para esta sala");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (vitrinas == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }

            return new ArrayList(vitrinas);
        }

        public void regresarObjeto()
        {
            regresarObjeto( this.id );
        }

        /*CONSULTAS*/

        public ArrayList consultarNumero( string numero )
        {
            List<Vitrina> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection( "?numero=" + numero );
                if( listaNueva == null )
                    Error.ingresarError( 2, "no se encontraron coincidencias con el numero: " + numero );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con el numero: " + numero );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Vitrina del numero: " + numero );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        /*CONSULTAR PADRE*/

        public Sala consultarSala()
        {
            Sala clase = new Sala();
            try
            {
                clase.regresarObjeto( this.sala );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias con sala: " + sala );
            }
            return ( clase );
        }

        /*CONSULTAR HIJOS*/

        public ArrayList regresarTraslados()
        {
            List<Traslado> listaNueva = null;
            try
            {
                Traslado clase = new Traslado();
                string consulta = clase.resource_uri + "?vitrina=" + this.id.ToString();
                listaNueva = clase.GetAsCollection( consulta );
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro ningun Trasladoa por el momento" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Traslados de Vitrina: " + this.numero );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public void eliminar()
        {
            try
            {
                if (this.id == 0)
                {
                    Error.ingresarError(2, "No existe la Vitrina en la base de datos para poder Eliminarla ");
                    return;
                }
                this.del();
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se ha eliminado la Vitrina Seleccionada " + e.Message);
            }
        }
    }
}
