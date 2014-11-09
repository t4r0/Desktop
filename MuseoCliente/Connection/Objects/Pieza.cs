using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;


namespace MuseoCliente.Connection.Objects
{
    public class Pieza : ResourceObject<Pieza>
    {
        [JsonProperty]
        public string codigo { get; set; }
        [JsonProperty]
        public string resumen { get; set; }
        [JsonProperty]
        public int clasificacion { get; set; }
        [JsonProperty]
        public int ? autor { get; set; }
        [JsonProperty]
        public string responsableRegistro { get; set; }
        [JsonProperty]
        public bool registroIDAEH { get; set; }
        [JsonProperty]
        public string codigoIDAEH { get; set; }
        [JsonProperty]
        public string archivoIDAEH { get; set; }
        [JsonProperty]
        public string nombre { get; set; }
        [JsonProperty]
        public string descripcion { get; set; }
        [JsonProperty]
        public DateTime fechaIngreso { get; set; }
        [JsonProperty]
        public string procedencia { get; set; }
        [JsonProperty]
        public string pais { get; set; }
        [JsonProperty]
        public int ? regionCultural { get; set; }
        [JsonProperty]
        public string observaciones { get; set; }
        [JsonProperty]
        public bool maestra { get; set; }
        [JsonProperty]
        public bool exhibicion { get; set; }
        [JsonProperty]
        public float ? altura { get; set; }
        [JsonProperty]
        public float ? ancho { get; set; }
        [JsonProperty]
        public float ? grosor { get; set; }
        [JsonProperty]
        public float ? largo { get; set; }
        [JsonProperty]
        public float ? diametro { get; set; }
        [JsonProperty]
        public string fotografia { get; set; }
        [JsonProperty]
        public String fechamiento { get; set; }


        public Pieza()
            : base( "/api/v1/piezas/" )
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
                //string error = e.Source;// para ver el nombre del error
                Error.ingresarError( 3, "No se ha guardado en la Informacion en la base de datos "+ e.Message );
            }
        }

        public bool ShouldSerializefotografia()
        {
            return false;
        }

        public void modificar()
        {
            try
            {
                this.Save( this.codigo );
            }
            catch( Exception e )
            {
                Error.ingresarError( 4, "No se ha modifico en la Informacion en la base de datos "+e.Message );
            }
        }
        /* FUNCINES ESCENCIALES*/

        public ArrayList regresarTodos()
        {
            List<Pieza> listaNueva = null;
            try
            {
                listaNueva = this.fetchAll();
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Piezas en la base de Datos" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public void regresarObjeto( string cod)
        {
            try
            {
                this.resource_uri = this.resource_uri + cod + "/";
                Pieza temp = this.Get();
                if( temp == null )
                {
                    Error.ingresarError( 2, "Este Objeto no existe porfavor, ingresar correcta la busqueda" );
                    return;
                }
                this.id =temp.id;
                this.resource_uri = temp.resource_uri;
                this.codigo = temp.codigo;
                this.resumen = temp.resumen;
                this.clasificacion = temp.clasificacion;
                this.autor = temp.autor;
                this.responsableRegistro = temp.responsableRegistro;
                this.registroIDAEH = temp.registroIDAEH;
                this.codigoIDAEH = temp.codigoIDAEH;
                this.archivoIDAEH = temp.archivoIDAEH;
                this.nombre = temp.nombre;
                this.descripcion = temp.descripcion;
                this.fechaIngreso = temp.fechaIngreso;
                this.procedencia = temp.procedencia;
                this.pais = temp.pais;
                this.regionCultural = temp.regionCultural;
                this.observaciones = temp.observaciones;
                this.maestra = temp.maestra;
                this.exhibicion = temp.exhibicion;
                this.altura = temp.altura;
                this.ancho = temp.ancho;
                this.grosor = temp.grosor;
                this.largo = temp.largo;
                this.diametro = temp.diametro;

            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
        }

        public void regresarObjeto()
        {
            regresarObjeto( this.codigo);
        }

        /*  CONSULTAS */
        public ArrayList buscarCodigo(string codigo)
        {
            List<Pieza> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection("?codigo__icontains=" + codigo);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen piezas con el nombre: " + codigo);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList buscarNombre( String nombre )
        {
            List<Pieza> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection( "?nombre__icontains=" + nombre );
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen piezas con el nombre: " + nombre );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList buscarResponsableEquipo( int responsable )
        {
            List<Pieza> listaNueva = null;
            try
            {
                string consultar =  "?responsableRegistro=" + responsable.ToString();
                listaNueva = this.GetAsCollection( consultar );
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Piezas con dicho responsable" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList buscarFechaIngreso( DateTime fecha )
        {
            List<Pieza> listaNueva = null;
            try
            {
                string consultar = "?fechaIngreso=" + fecha.Date.ToString();
                listaNueva = this.GetAsCollection( consultar );
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Piezas con dicha fecha: " + fecha.Date.ToString() );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList buscarRegionCultural( int regionCultural )
        {
            List<Pieza> listaNueva = null;
            try
            {
                string consultar =  "?regionCultural=" + regionCultural;
                listaNueva = this.GetAsCollection( consultar );
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se existen piezas con la region Cultural recibida" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList buscarExibicion()
        {
            List<Pieza> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection( "?exhibicion=true" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron piezas en exhibicion" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Piezas que esten en Exibicion" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList buscarClasificacion( int clasificacion )
        {
            List<Pieza> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection( "?clasificacion=" + clasificacion );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron piezas con clasificacion" + clasificacion );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron piezas con clasificacion" + clasificacion );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList regresarOrdenadasPorClasificacion()
        {
            List<Pieza> listaNueva = null;
            try
            {
                List<Pieza> temp = this.fetchAll();
                var temp2 = temp.OrderBy( x => x.clasificacion ).ToList();
                listaNueva = temp2;
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontraron piezas con clasificacion" + clasificacion );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron piezas con clasificacion" + clasificacion );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList buscarBodega()
        {
            List<Pieza> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection( "?exhibicion=false" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no hay piezas en bodega" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Piezas que esten en bodega" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList buscarUltimasIngresadas()
        {
            List<Pieza> listaNueva = null;
            try
            {
                var temp = this.fetchAll();
                var temp2 = from x in temp where x.fechaIngreso <= DateTime.Now select x;
                listaNueva = temp2.ToList();
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no hay piezas en bodega" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No existen Piezas que esten en bodega" );
                return null;
            }
            return new ArrayList( listaNueva );
        }
        /*  CONSULTAS DE PADRES*/
        public Clasificacion regresarClasificaciones()
        {
            Clasificacion consol = new Clasificacion();
            try
            {
                consol.regresarObjeto( this.clasificacion );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No existe Coneccion" );
            }
            return ( consol );
        }

        public Autor consultarAutor()
        {
            Autor autor = new Autor();
            try
            {
                autor.regresarObjeto( this.autor.Value );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }

            return ( autor );
        }

        /*CONSULTAS DE HIJOS*/

        public ArrayList regresarConsolidacion()
        {
            List<Consolidacion> listaNueva = null;
            try
            {
                Consolidacion clase = new Consolidacion();
                string consulta =  "?pieza=" + this.codigo;
                listaNueva = clase.GetAsCollection( consulta );
                if( listaNueva == null )
                    Error.ingresarError( 2, "No se encontro Consolidacion" );
            }
            catch( Exception e )
            {
                Error.ingresarError( 5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron Consolidaciones de Pieza: " + this.nombre );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList regresarTraslados()
        {
            List<Traslado> listaNueva = null;
            try
            {
                Traslado clase = new Traslado();
                string consulta = clase.resource_uri + "?pieza=" + this.codigo;
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
                Error.ingresarError( 2, "No existen Traslados de la pieza: " + this.nombre );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList regresarRegistro()
        {
            List<Registro> listaNueva = null;
            try
            {
                Registro clase = new Registro();
                string consulta = "?pieza=" + this.codigo;
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
                Error.ingresarError( 2, "No existen Registros de la Pieza: " + this.nombre );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList regresarFotografia()
        {
            List<Fotografia> listaNueva = null;
            try
            {
                Fotografia clase = new Fotografia();
                string consulta = "?pieza=" + this.codigo;
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
                Error.ingresarError( 2, "No existen Fotografias de Pieza: " + this.nombre );
                return null;
            }
            return new ArrayList( listaNueva );
        }

    }
}
