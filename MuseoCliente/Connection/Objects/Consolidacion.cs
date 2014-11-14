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
    public class Consolidacion:ResourceObject<Consolidacion>
    {
        [JsonProperty]
        public Boolean limpieza { get; set; }
        [JsonProperty]
        public DateTime fechaInicio { get; set; }
        [JsonProperty]
        public DateTime fechaFin { get; set; }
        [JsonProperty]
        public string responsable { get; set; }
        [JsonProperty]
        public string pieza { get; set; }
        [JsonProperty]
        public List<Mantenimiento> mantenimientos { get; set; }

        private List<Mantenimiento> manNuevo;

        private void igualarLista(List<Mantenimiento> nuevo, List<Mantenimiento> viejo)
        {
            nuevo.Clear();
            foreach (Mantenimiento temp in viejo)
            {
                temp.consolidacion = this.id;
                nuevo.Add(temp);
            }
            viejo.Clear();
        }

        public Consolidacion(): base("/api/v1/consolidacion/")
        {
            mantenimientos = new List<Mantenimiento>();
            manNuevo = new List<Mantenimiento>();
        }

         public void guardar() //Crear un Usuario
        {
            try
            {
                igualarLista(manNuevo, mantenimientos);
                this.id = Deserialize(this.Create()).id;
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
            }
            igualarLista(mantenimientos, manNuevo);
            try
            {

                foreach (Mantenimiento man in mantenimientos)
                    man.guardar();
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
            }
             
        }


        public void modificar() //Modifica datos de un pais
        {
            List<Mantenimiento> temp = new List<Mantenimiento>();
            try
            {
                temp.Clear();
                foreach (Mantenimiento te in mantenimientos)
                {
                    if (te.id == 0)
                    {
                        te.consolidacion = this.id;
                        temp.Add(te);
                    }
                    else
                        te.modificar();
                }
                igualarLista(mantenimientos, temp);

                this.Save(this.id.ToString());
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
            }
        }

        

        public ArrayList regresarMantenimiento()
        {
            ArrayList listaNueva = null;
            try
            {
                Mantenimiento Mantenimiento = new Mantenimiento();
                List<Mantenimiento> Mantenimientos = Mantenimiento.GetAsCollection(Mantenimiento.resource_uri + "?autor=" + this.id);
                listaNueva = new ArrayList(Mantenimientos);
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarRegistro()
        {
            ArrayList listaNueva = null;
            try
            {
                Registro Registro = new Registro();
                List<Registro> Registros = Registro.GetAsCollection(Registro.resource_uri + "?consolidacion=" + this.id);
                listaNueva = new ArrayList(Registros);
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }
            return listaNueva;
        }


        public ArrayList consultarNombre(string responsable)//1
        {
            List<Consolidacion> listaNueva = null;
            try
            {
                string consultarResponsable =this.resource_uri + "?responsable=" + responsable;
                listaNueva = this.GetAsCollection(consultarResponsable);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro");
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
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
                this.resource_uri = this.resource_uri + id + "/";
                Consolidacion consolidacionTemp = this.Get();
                if (consolidacionTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = consolidacionTemp.id;
                this.limpieza = consolidacionTemp.limpieza;
                this.fechaInicio = consolidacionTemp.fechaInicio;
                this.fechaFin = consolidacionTemp.fechaFin;
                this.responsable = consolidacionTemp.responsable;
                this.pieza = consolidacionTemp.pieza;
                igualarLista(this.mantenimientos, consolidacionTemp.mantenimientos);
                this.resource_uri = resource_uri;
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
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
                listaNueva = new ArrayList(this.fetchAll());
            }
            catch (Exception e)
            {
                Error.ingresarError(e.Message);
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro la busqueda");
                return null;
            }

            return listaNueva;
        }
        public void ingresarMantenimiento(List<Mantenimiento> mante)
        {
            mantenimientos.Clear();
            foreach (Mantenimiento temp in mante)
            {
                mantenimientos.Add(temp);
            }
        }

        
    }
}
