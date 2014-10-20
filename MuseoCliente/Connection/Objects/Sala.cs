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


        public Sala(): base("v1/salas/")
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

        public ArrayList consultarNombre(string nombre)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Sala> lista = (ICollection<Sala>)this.GetAsCollection();
                var Salas = from sala in lista where sala.nombre == nombre select sala;
                listaNueva.AddRange((ICollection)Salas);
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
            ArrayList listaNueva = null;
            try
            {
                ICollection<Sala> lista = (ICollection<Sala>)this.GetAsCollection();
                var Salas = from sala in lista where sala.descripcion == descripcion select sala;
                listaNueva.AddRange((ICollection)Salas);
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
            ArrayList listaNueva = null;
            try
            {
                ICollection<Sala> lista = (ICollection<Sala>)this.GetAsCollection();
                var Salas = from sala in lista where sala.fotografia == fotografia select sala;
                listaNueva.AddRange((ICollection)Salas);
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
