using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Clasificacion:ResourceObject<Clasificacion>
    {
        [JsonProperty]
        public int coleccion { get; set; }
        [JsonProperty]
        public int categoria { get; set; }
        [JsonProperty]
        public int ficha { get; set; }
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public String codigo { get; set; }

        public Clasificacion() : base("v1/clasificacion/")
        {

        }
        public void guardar()
        {
            try
            {
                this.Create();
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(3, "No se ha guardado la Informacion en la base de datos");
                }
            }
        }

        public void modificar(string id)
        {
            try
            {
                this.Save(id);
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

        public ArrayList consultarColeccion(int coleccion)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Clasificacion> lista = (ICollection<Clasificacion>)this.GetAsCollection();
                var Clasificaiones = from clasificacion in lista where clasificacion.coleccion == coleccion select clasificacion;
                listaNueva.AddRange((ICollection)Clasificaiones);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con coleccion: " + coleccion);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con coleccion: " + coleccion);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarCategoria(int categoria)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Clasificacion> lista = (ICollection<Clasificacion>)this.GetAsCollection();
                var Clasificaiones = from clasificacion in lista where clasificacion.categoria == categoria select clasificacion;
                listaNueva.AddRange((ICollection)Clasificaiones);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con categoria: " + categoria);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con categoria: " + categoria);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarFicha(int ficha)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Clasificacion> lista = (ICollection<Clasificacion>)this.GetAsCollection();
                var Clasificaiones = from clasificacion in lista where clasificacion.ficha == ficha select clasificacion;
                listaNueva.AddRange((ICollection)Clasificaiones);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con ficha: " + ficha);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con ficha: " + ficha);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarNombre(string nombre)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Clasificacion> lista = (ICollection<Clasificacion>)this.GetAsCollection();
                var Clasificaiones = from clasificacion in lista where clasificacion.nombre == nombre select clasificacion;
                listaNueva.AddRange((ICollection)Clasificaiones);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarCodigo(string codigo)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Clasificacion> lista = (ICollection<Clasificacion>)this.GetAsCollection();
                var Clasificaiones = from clasificacion in lista where clasificacion.codigo == codigo select clasificacion;
                listaNueva.AddRange((ICollection)Clasificaiones);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con codigo: " + codigo);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con codigo: " + codigo);
            }
            return new ArrayList(listaNueva);
        }
    }
}
