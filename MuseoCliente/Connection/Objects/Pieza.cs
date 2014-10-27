using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;


namespace MuseoCliente.Connection.Objects
{
    class Pieza: ResourceObject<Pieza>
    {
        [JsonProperty]
        public String codigo { get; set; }
        [JsonProperty]
        public String codigoSlug { get; set; }
        [JsonProperty]
        public int clasificacion { get; set; }
        [JsonProperty]
        public int autor {get;set;}
        [JsonProperty]
        public int responsableRegistro {get;set;}
        [JsonProperty]
        public Boolean registroIDAEH { get; set; }
        [JsonProperty]
        public String codigoIDAEH { get; set; }
        [JsonProperty]
        public String archivoIDAEH { get; set; }
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public String descripcion { get; set; }
        [JsonProperty]
        public DateTime fechaIngreso { get; set; }
        [JsonProperty]
        public String procedencia { get; set; }
        [JsonProperty]
        public string pais { get; set; }
        [JsonProperty]
        public Int16 regionCultural { get; set; }
        [JsonProperty]
        public String observaciones { get; set; }
        [JsonProperty]
        public Boolean maestra { get; set; }
        [JsonProperty]
        public Boolean exhibicion { get; set; }
        [JsonProperty]
        public float altura { get; set; }
        [JsonProperty]
        public float ancho { get; set; }
        [JsonProperty]
        public float grosor { get; set; }
        [JsonProperty]
        public float largo { get; set; }
        [JsonProperty]
        public float diametro { get; set; }


        public Pieza()
            : base("/api/v1/piezas/")
        {
        }

		public void guardar()
		{
			try
			{
				this.Create();
			}
			catch( Exception e)
			{
                //string error = e.Source;// para ver el nombre del error
				Error.ingresarError(3,"No se ha guardado en la Informacion en la base de datos");
			}
		}
		
		public void modificar()
		{
			try
			{
				this.Save(this.codigo);
			}
			catch( Exception e)
			{
				Error.ingresarError(4,"No se ha modifico en la Informacion en la base de datos");
			}		
		}
        /* FUNCINES ESCENCIALES*/

        public ArrayList regresarTodos()
        {
            List<Pieza> listaNueva = null;
            try
            {
                listaNueva = this.GetAsCollection();
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Piezas en la base de Datos");
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public void regresarObjeto(int id)
        {
            try
            {
                Pieza temp = this.Get(id.ToString());
                if (temp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.codigo = temp.codigo;
                this.codigoSlug = temp.codigoSlug;
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
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
        }

        public void regresarObjeto()
        {
            regresarObjeto(this.id);
        }

        /*  CONSULTAS */
        


        public ArrayList buscarNombre(String nombre)
        {
            List<Pieza> listaNueva = null;
			try{
                string consultar = this.resource_uri + "?nombre__contains=" + nombre;
                listaNueva = this.GetAsCollection(consultar);
                if(listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
			}catch(Exception e)
			{
				Error.ingresarError(2,"No se encontro nombre similares");
			}
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen piezas con el nombre: "+nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList buscarResponsableEquipo(int responsable)
        {
            List<Pieza> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?responsableRegistro=" + responsable.ToString();
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Piezas con dicho responsable");
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList buscarFechaIngreso(DateTime fecha)
        {
            List<Pieza> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?fechaIngreso=" + fecha.Date.ToString();
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Piezas con dicha fecha: "+fecha.Date.ToString());
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList buscarRegionCultural(int regionCultural)
        {
            List<Pieza> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?regionCultural=" + regionCultural;
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se existen piezas con la region Cultural recibida");
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList  buscarExibicion(bool exib)
        {
            List<Pieza> listaNueva = null;
            try
            {
                string consultar = this.resource_uri+"?exhibicion=" + exib.ToString();
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Piezas con que esten en Exibicion: "+exib.ToString());
                return null;
            }
            return new ArrayList(listaNueva);
        }

        
        /*  CONSULTAS DE PADRES*/
        public Clasificacion regresarClasificaciones()
        {
            Clasificacion consol = new Clasificacion();
            try
            {
                consol.regresarObjeto(this.clasificacion);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No existe Coneccion");
            }
            return (consol);
        }

        public Autor consultarAutor()
        {
            Autor autor = new Autor();
            try
            {
                autor.regresarObjecto(this.autor);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }

            return (autor);
        }

        /*CONSULTAS DE HIJOS*/

        public ArrayList regresarConsolidacion()
        {
            List<Consolidacion> listaNueva = null;
            try
            {
                Consolidacion clase = new Consolidacion();
                string consulta = clase.resource_uri+"?pieza=" + this.codigo;
                listaNueva = clase.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro Consolidacion");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron Consolidaciones de Pieza: "+this.nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList regresarTraslados()
        {
            List<Traslado> listaNueva = null;
            try
            {
                Traslado clase = new Traslado();
                string consulta = clase.resource_uri+"?pieza=" + this.codigo;
                listaNueva = clase.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ningun Trasladoa por el momento");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Traslados de la pieza: "+this.nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList regresarRegistro()
        {
            List<Registro> listaNueva = null;
            try
            {
                Registro clase = new Registro();
                string consulta = clase.resource_uri+"?pieza=" + this.codigo;
                listaNueva = clase.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ningun Trasladoa por el momento");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Registros de la Pieza: "+this.nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList regresarFotografia()
        {
            List<Fotografia> listaNueva = null;
            try
            {
                Fotografia clase = new Fotografia();
                string consulta = clase.resource_uri+"?pieza=" + this.codigo;
                listaNueva = clase.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ningun Trasladoa por el momento");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No existen Fotografias de Pieza: "+this.nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }

    }
}
