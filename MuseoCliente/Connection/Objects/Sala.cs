using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Sala:ResourceObject<Sala>
    {
        [JsonProperty]
        public String nombre { get; set; }
        [JsonProperty]
        public String descripcion { get; set; }
        [JsonProperty]
        public String fotografia { get; set; }
       


        public Sala(): base("/api/v1/salas/")
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

        /*FUNCIONES ESCENCIALES*/
        public ArrayList regresarTodos()
        {
            List<Sala> lista = null;
            try
            {
                lista = this.GetAsCollection();
                if (lista == null)
                    Error.ingresarError(2, "No se econtro ninguna Ficha registrada");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (lista == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            

            return new ArrayList(lista);
        }

        public void regresarObjeto(int ide)
        {
            try
            {
                Sala salaTemporal = this.Get(ide.ToString());
                if (salaTemporal == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.nombre = salaTemporal.nombre;
                this.id = salaTemporal.id;
                this.descripcion = salaTemporal.descripcion;
                this.fotografia = salaTemporal.fotografia;
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

        /*CONSULTAS*/

        public ArrayList consultarNombre(string nombre)
        {
            List<Sala> listaNueva = null;
            try
            {
                string consultar =this.resource_uri + "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultar); 
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            return new ArrayList(listaNueva);
        }

        /*CONSULTAS DE HIJOS*/
        public ArrayList consultarVitrina()
        {
            List<Vitrina> vitrina = null;
            try
            {
                Vitrina clas = new Vitrina();
                string consulta = clas.resource_uri + "?sala" + this.id.ToString();
                vitrina = clas.GetAsCollection(consulta);
                if (vitrina == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (vitrina == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            
            return new ArrayList(vitrina);
        }

        public ArrayList consultarEventos()
        {
            List<Eventos> evento = null;
            try
            {
                Eventos clas = new Eventos();
                string consulta =clas.resource_uri + "?sala" + this.id.ToString();
                evento = clas.GetAsCollection(consulta);
                if (evento == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (evento == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            

            return new ArrayList(evento);
        }

        
    }
}
