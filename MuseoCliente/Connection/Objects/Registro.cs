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
    public class Registro : ResourceObject<Registro>
    {
        
        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public Boolean consolidacion { get; set; }

        public Registro()
            : base("/api/v1/registro/")
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
                Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos");
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
                Error.ingresarError(4, "No se ha modifico en la Informacion en la base de datos");
            }
        }

        public ArrayList regresarCampo()
        {
            ArrayList listaNueva = null;
            try
            {
                Campo Campo = new Campo();
                List<Campo> Campos = Campo.GetAsCollection(Campo.resource_uri + "?registro=" + this.id);
                listaNueva = new ArrayList(Campos);
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

        public ArrayList consultarFecha(string fecha)//1
        {
            List<Registro> listaNueva = null;
            try
            {
                string consultarFecha = this.resource_uri + "?fecha=" + fecha;
                listaNueva = this.GetAsCollection(consultarFecha);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro Clasi");
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
                Registro registroTemp = this.Get(id.ToString());
                if (registroTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = registroTemp.id;
                this.fecha = registroTemp.fecha;
                this.consolidacion = registroTemp.consolidacion;
                

            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
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

        //Consultar PADRE

        

    }
}
