using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    public class LinkInvestigacion:ResourceObject<LinkInvestigacion>
    {
        public LinkInvestigacion():base("v1/linkInvestigacion/")
        {

        }
        
        [JsonProperty]
        public string link { get; set; }

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

        public ArrayList consultarLink(string link)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<LinkInvestigacion> lista = (ICollection<LinkInvestigacion>)this.GetAsCollection();
                var links = from linkInvestigacion in lista where linkInvestigacion.link == link select linkInvestigacion;
                listaNueva.AddRange((ICollection)links);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con link: " + link);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con link: " + link);
            }
            return new ArrayList(listaNueva);
        }

    }
}
