using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Categoria : ResourceObject<Categoria>
    {
        [JsonProperty]
        public string nombre { get; set; }

        public Categoria()
            : base( "/api/v1/categorias/" )
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
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron Categorias con el nombre: "+nombre);
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarClasificacion()
        {
            ArrayList listaNueva = null;
            try
            {
                Clasificacion Clasificacion = new Clasificacion();
                List<Clasificacion> Clasificaciones = Clasificacion.GetAsCollection( Clasificacion.resource_uri + "?categoria=" + this.id );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron clasificaciones para esta categoria" );
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron Clasificaciones de la Categoria "+this.nombre);
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarTodo()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection());
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "tabla vacia" );
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Categoria");
                return null;
            }
            return listaNueva;
        }

        public void regresarObjeto(int id)
        {
            try
            {
                Categoria fichaTemp = this.Get(id.ToString());
                if (fichaTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = fichaTemp.id;
                this.nombre = fichaTemp.nombre;
                this.resource_uri = fichaTemp.resource_uri;
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
        }
        public void regresarObjeto()
        {
            regresarObjeto(this.id);
        }
    }
}
