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
            : base("/api/v1/publicacion/")
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


        public ArrayList consultarNombre(String nombre)
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList(this.GetAsCollection("?nombre__contains=" + nombre));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "Nose encontro el nombre =" + nombre);
                return null;
            }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultapublicacion(string publicacion)  //  la acabo de agregar segun la clase fichas 
        {
            ArrayList  listaNueva = null;
            try
            {

                listaNueva = new ArrayList(this.GetAsCollection("?publicacion__contains=" + publicacion));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontraron publicaciones similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "Nose encontro la publicacion =" + publicacion);
                return null;
            }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultalink(string link)  //  la acabo de agregar segun la clase fichas 
        {
            ArrayList  listaNueva = null;
            try
            {

                listaNueva = new ArrayList(this.GetAsCollection("?link__contains=" + link));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontraron link's similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "Nose encontro el link =" + link);
                return null;
            }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultapublicacionfecha(DateTime fecha)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            ArrayList listaNueva = null;
            try
            {


                string fecha2 = fecha.Date.ToString();
                listaNueva = new ArrayList(this.GetAsCollection("?fecha__contains=" + fecha2));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontraron link's similares");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "Nose encontro el link =" + link);
                return null;
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList regresarTodos()
        {
            List<Publicacion> listaNueva = null;
            try
            {
                listaNueva = this.fetchAll();
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "tabla vacia");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontraron coincidencias");
                return null;
            }
            return new ArrayList(listaNueva);
        }

           

        public ArrayList regresarPublicaciones()
        {
            List<Publicacion> listaNueva = null;
            try
            {
                Publicacion clas = new Publicacion();
                string consulta = this.resource_uri + "?nombre=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
               
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se encontro nombre similares");
                return null;
                }
            return new ArrayList(listaNueva);
        }


        public void regresarObjeto(int id)
        {
            this.resource_uri = this.resource_uri + id + "/";
            Publicacion Temp = this.Get();
            if (Temp == null)
            {
                Error.ingresarError(2, "No se encontro coincidencia");
                return;
            }
            this.id = Temp.id;
            this.fecha = Temp.fecha;
            this.link = Temp.link;
            this.nombre = Temp.nombre;
            this.publicacion = Temp.publicacion;
            this.resource_uri = Temp.resource_uri;
        }


       
    }
}