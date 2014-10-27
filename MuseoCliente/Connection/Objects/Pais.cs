using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Pais : ResourceObject<Pais>
    {

        public Pais()
            : base( "/api/v1/paises/" )
        {

        }

        [JsonProperty]
        public string name { get; set; }

        [JsonProperty]
        public string printable_name { get; set; }

        [JsonProperty]
        public string iso3 { get; set; }

        [JsonProperty]
        public string iso { get; set; }

        [JsonProperty]
        public int numcode { get; set; }


        public void guardar() //Crear un Usuario
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


        public void modificar() //Modifica datos de un pais
        {
            try
            {
                this.Save( this.iso );
            }
            catch( Exception e )
            {
                Error.ingresarError( 4, "No se ha modifico en la Informacion en la base de datos" );
            }
        }

        /*FUNCIONES ESCENCIALES*/

        public ArrayList regresarTodos()
        {
            List<Pais> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection();
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se econtro ninguna Ficha registrada" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public void regresarObjeto( int ide )
        {
            try
            {
                Pais salaTemporal = this.Get( ide.ToString() );
                if( salaTemporal == null )
                {
                    Error.ingresarError( 2, "Este Objeto no existe porfavor, ingresar correcta la busqueda" );
                    return;
                }
                this.name = salaTemporal.name;
                this.printable_name = salaTemporal.printable_name;
                this.iso3 = salaTemporal.iso3;
                this.iso = salaTemporal.iso;
                this.numcode = salaTemporal.numcode;
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


        public ArrayList buscarNombre( String nombre ) //Devuelve lista de todos los paises ingresados
        {
            List<Pais> listaNueva = null;
            try
            {
                string consultar = "?name=" + nombre;
                listaNueva = this.GetAsCollection( consultar );

                if( listaNueva == null )
                    Error.ingresarError( 2, "No hay paises existentes" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No hay paises existentes" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList( listaNueva );
        }



    }
}