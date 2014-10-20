using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Fotografia:ResourceObject<Fotografia>
    {
        [JsonProperty]
        public int mantenimiento { get; set; }
        [JsonProperty]
        public int pieza { get; set; }
        [JsonProperty]
        public Int16 tipo { get; set; }
        [JsonProperty]
        public String ruta { get; set; }
        [JsonProperty]
        public Boolean perfil { set; get; }

        public Fotografia()
            : base("/v1/fotografias/")
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
                //string error = e.Source;// para ver el nombre del error
                Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos");
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
                Error.ingresarError(4, "No se ha modifico en la Informacion en la base de datos");
            }
        }

        public ArrayList consultarTipo(Int16 tipo)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                ICollection<Fotografia> todasFotografia = (ICollection<Fotografia>)this.GetAsCollection();
                var fotoTipo = from foto in todasFotografia
                               where foto.tipo == tipo
                               select foto;
                listaNueva.AddRange((ICollection)fotoTipo);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarPerfil(Boolean perfil)
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                ICollection<Fotografia> todasFotografia = (ICollection<Fotografia>)this.GetAsCollection();
                var fotoPerfil = from foto in todasFotografia
                                 where foto.perfil == perfil
                                 select foto;
                listaNueva.AddRange((ICollection)fotoPerfil);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            return new ArrayList(listaNueva);
        }
    }
}
