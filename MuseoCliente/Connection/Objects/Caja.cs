using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Caja:ResourceObject<Caja>
    {
        [JsonProperty]
        public String codigo { get; set; }

        public Caja() : base("v1/cajas/")
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

        public ArrayList consultarNombre(string codigo)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Caja> lista = (ICollection<Caja>)this.GetAsCollection();
                var Traslados = from caja in lista where caja.codigo == codigo select caja;
                listaNueva.AddRange((ICollection)lista);
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
