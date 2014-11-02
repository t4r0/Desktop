using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    public class Eventos:ResourceObject<Eventos>
    {
        [JsonProperty]
        public String afiche { get; set; }
        [JsonProperty]
        public String descripcion { get; set; }
        [JsonProperty]
        public DateTime fecha { get; set; }
        [JsonProperty]
        public string fotoSala { get; set; }
        [JsonProperty]
        public string hora { get; set; }
        [JsonProperty]
        public String  nombre { get; set; }       
        [JsonProperty]
        public int sala { get; set; }
        [JsonProperty]
        public int usuario { get; set; }

        public Eventos(): base("/api/v1/eventos/")
        {
           
        }

        public bool ShouldSerializefotoSala()
        {
            return false;
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

        public ArrayList consultarNombre(string nombre)  //  la acabo de agregar segun la clase fichas 
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultarNombre = this.resource_uri + "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con el nombre");
                return null;
            }

            return new ArrayList(listaNueva);
        }
                
        public ArrayList consultardescripcion(string descripcion)  //  la acabo de agregar segun la clase fichas  segunda agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultardescripcion = this.resource_uri + "?descripcion=" + descripcion;
                listaNueva = this.GetAsCollection(consultardescripcion);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con la descripcion");
                return null;
            }

            return new ArrayList(listaNueva);
        }
        
        public ArrayList consultarafiche(string afiche)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultarafiche = this.resource_uri + "?afiche=" + afiche;
                listaNueva = this.GetAsCollection(consultarafiche);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con el afiche");
                return null;
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultaraficheporfecha(DateTime fecha)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                               
                string fecha2 = fecha.Date.ToString();
                string consultaraficheporfecha = this.resource_uri + "?fecha2=" + fecha2;
                listaNueva = this.GetAsCollection(consultaraficheporfecha);
                
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
                {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con la fecha");
                return null;
                }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultaraficheporsala(int sala)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {

                string sala2 = sala.ToString();
                //fecha.Date.ToString();
                string consultaraficheporsala = this.resource_uri + "?sala=" + sala2;
                listaNueva = this.GetAsCollection(consultaraficheporsala);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }
            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con la sala");
                return null;
            }
            return new ArrayList(listaNueva);
        }


        public ArrayList consultareventoporusuario(int usuario)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {

                string usuario2 = usuario.ToString();
                //fecha.Date.ToString();
                string consultareventoporusuario = this.resource_uri + "?usuario=" + usuario2;
                listaNueva = this.GetAsCollection(consultareventoporusuario);

                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia con el usuario");
                return null;
            }

            return new ArrayList(listaNueva);
        }


        public void regresarObjeto(int id)
        {
            try
            {
                Eventos eventosTemp = this.Get();
                if (eventosTemp == null)
                {
                    Error.ingresarError(2, "Este Objeto no existe porfavor, ingresar correcta la busqueda");
                    return;
                }
                this.id = eventosTemp.id;
                this.nombre = eventosTemp.nombre;
                this.descripcion = eventosTemp.descripcion;
                this.afiche = eventosTemp.afiche;
                this.fecha = eventosTemp.fecha;
                this.sala = eventosTemp.sala;
                this.usuario = eventosTemp.usuario;
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


        public ArrayList regresarTodos()
        {
            ArrayList listaNueva = null;
            try
            {
                
                List<Eventos> todoseventos = this.GetAsCollection();
                                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna al parecer la tabla esta vacia");
                return null;
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarEventos()
        {
            List<Eventos> listaNueva = null;
            try
            {
                Eventos clas = new Eventos();
                string consulta = this.resource_uri + "?eventos=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);
                
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            if (listaNueva == null)
            {
                Error.ingresarError(2, "No se encontro ninguna coincidencia ");
                return null;
            }

            return new ArrayList(listaNueva);
        }




    }
}
