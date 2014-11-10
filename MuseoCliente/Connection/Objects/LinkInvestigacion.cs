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
        public LinkInvestigacion(string link)
            : base("/api/v1/links/")
        {
            this.link = link;
            this.id = 0;
        }

        public LinkInvestigacion()
            : base("/api/v1/links/")
        {
            this.id = 0;
        }
        
        [JsonProperty]
        public string link { get; set; }

        [JsonProperty]
        public int investigacion { get; set; }

        public void guardar()
        {
            try
            {
                this.id=this.Deserialize(this.Create()).id;
            }
            catch (Exception e)
            {
                if (e.Source != null)
                {
                    Error.ingresarError(3, "No se ha guardado la Informacion en la base de datos"+e.Message.ToString());
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

        public ArrayList consultarLink(string link)
        {
            List<LinkInvestigacion> listaNueva = new List<LinkInvestigacion>();
            try
            {
                List<LinkInvestigacion> todasPiezas = this.fetchAll();
                foreach (LinkInvestigacion Link in todasPiezas)
                {
                    if (Link.link.Contains(link))
                        listaNueva.Add(Link);
                }
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con link: " + link);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con link: " + link);
            }
            return new ArrayList(listaNueva);
        }

        public void eliminar()
        {
            try
            {
                this.del();
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con link: " + e.Message);
            }
        }

    }
}
