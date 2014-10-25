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
    public class Publicacion : ResourceObject<Publicacion>
    {

        public Publicacion()
            : base("/v1/publicacion/")
        {
            

        }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public string nombre { get; set; }

        [JsonProperty]
        public string publicacion { get; set; }

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


        public ArrayList consultarNombre(String nombre)
        {
            ArrayList listaNueva = new ArrayList(); 
          
            try
            {

                List<Publicacion> todasPublicaciones = this.GetAsCollection();
                foreach (Publicacion hol in todasPublicaciones)
                {
                    if (hol.nombre.Contains(nombre))
                        listaNueva.Add(hol);
                }

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro publicacion");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro publicacion");
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultapublicacion(string publicacion)  //  la acabo de agregar segun la clase fichas 
        {
            List<Publicacion> listaNueva = null;
            try
            {
                string consultarpublicacion = "?publicacion=" + publicacion;
                listaNueva = this.GetAsCollection(consultarpublicacion);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro el nombre del evento");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultalink(string link)  //  la acabo de agregar segun la clase fichas 
        {
            List<Publicacion> listaNueva = null;
            try
            {
                string consultalink = "?link=" + link;
                listaNueva = this.GetAsCollection(consultalink);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro el link de la publicacion");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultapublicacionfecha(DateTime fecha)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Publicacion> listaNueva = null;
            try
            {


                string fecha2 = fecha.Date.ToString();
                string consultapublicacionfecha = "?fecha2=" + fecha2;
                listaNueva = this.GetAsCollection(consultapublicacionfecha);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia con la fecha");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarTodos()
        {
            ArrayList listaNueva = new ArrayList();
            try
            {

                List<Publicacion> todaspublicacion = this.GetAsCollection();

                if (listaNueva == null)
                    Error.ingresarError(2, "No se econtro ninguna Ficha registrada");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarPublicaciones()
        {
            List<Publicacion> listaNueva = null;
            try
            {
                Publicacion clas = new Publicacion();
                string consulta = "?nombre=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }
       
    }
}