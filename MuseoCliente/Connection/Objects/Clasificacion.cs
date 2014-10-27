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

        public Clasificacion() : base("/api/v1/clasificacion/")
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

        public void modificar()
        {
            try
            {
                this.Save(this.id.ToString());
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }


        public ArrayList regresarPieza()
        {
            ArrayList listaNueva = null;
            try
            {
                Pieza Pieza = new Pieza();
                List<Pieza> Piezas = Pieza.GetAsCollection(Pieza.resource_uri + "?clasificacion=" + this.id);
                listaNueva = new ArrayList(Piezas);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontraron piezas de este autor");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
           
            return listaNueva;
        }

        public ArrayList consultarNombre(string nombre)//1
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                string consultarNombre = "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            

            return new ArrayList(listaNueva);
        }

        public void regresarObjeto(int id)//2
        {
            try
            {
                Clasificacion fichaTemp = this.Get(id.ToString());
                if (fichaTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = fichaTemp.id;
                this.coleccion = fichaTemp.coleccion;
                this.categoria = fichaTemp.categoria;
                this.ficha = fichaTemp.ficha;
                this.nombre = fichaTemp.nombre;
                this.codigo = fichaTemp.codigo;
            
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Por favor Verifique su coneccion a Internet");
            }
        }

        public void regresarObjeto()//3
        {
            regresarObjeto(this.id);
        }

        public ArrayList regresarTodo()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList(this.GetAsCollection());
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "tabla vacia");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            
            return listaNueva;
        }

      }
}
