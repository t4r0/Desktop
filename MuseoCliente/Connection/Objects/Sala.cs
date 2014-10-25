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
       


        public Sala(): base("/v1/salas/")
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


        public ArrayList consultarNombre(string nombre)
        {
            List<Sala> listaNueva = new List<Sala>();
            try
            {
                List<Sala> todasPiezas = this.GetAsCollection();
                foreach (Sala sala in todasPiezas)
                {
                    if (sala.nombre.Contains(nombre))
                        listaNueva.Add(sala);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con nombre: " + nombre);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarDescripcion(string descripcion)
        {
            List<Sala> listaNueva = new List<Sala>();
            try
            {
                List<Sala> todasPiezas = this.GetAsCollection();
                foreach (Sala sala in todasPiezas)
                {
                    if (sala.descripcion.Contains(descripcion))
                        listaNueva.Add(sala);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con descripcion: " + descripcion);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con descripcion: " + descripcion);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarFotografia(string fotografia)
        {
            List<Sala> listaNueva = new List<Sala>();
            try
            {
                List<Sala> todasPiezas = this.GetAsCollection();
                foreach (Sala sala in todasPiezas)
                {
                    if (sala.fotografia.Contains(fotografia))
                        listaNueva.Add(sala);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con fotografia: " + fotografia);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con fotografia: " + fotografia);
            }
            return new ArrayList(listaNueva);
        }
    }
}
