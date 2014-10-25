using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Eventos:ResourceObject<Eventos>
    {
        [JsonProperty]
        public String  nombre { get; set; }
        [JsonProperty]
        public String descripcion { get; set; }
        [JsonProperty]
        public String afiche { get; set; }
        [JsonProperty]
        public DateTime fecha { get; set; }
        [JsonProperty]
        public int sala { get; set; }
        [JsonProperty]
        public int usuario { get; set; }

        public Eventos()
            : base("/v1/eventos/")
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

        public void modificar(int id)
        {
            try
            {
                this.Save(id.ToString());
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
                string consultarNombre = "?nombre=" + nombre;
                listaNueva = this.GetAsCollection(consultarNombre);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro el nombre del evento");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }
                
        public ArrayList consultardescripcion(string descripcion)  //  la acabo de agregar segun la clase fichas  segunda agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultardescripcion = "?descripcion=" + descripcion;
                listaNueva = this.GetAsCollection(consultardescripcion);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro la descripcion");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }
        
        public ArrayList consultarafiche(string afiche)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                string consultarafiche = "?afiche=" + afiche;
                listaNueva = this.GetAsCollection(consultarafiche);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia con el afiche");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultaraficheporfecha(DateTime fecha)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Eventos> listaNueva = null;
            try
            {
                
                
                string fecha2 = fecha.Date.ToString();
                string consultaraficheporfecha = "?fecha2=" + fecha2;
                listaNueva = this.GetAsCollection(consultaraficheporfecha);
                
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia con la fecha");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
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
                string consultaraficheporsala = "?sala2=" + sala2;
                listaNueva = this.GetAsCollection(consultaraficheporsala);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia con el id de la sala");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
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
                string consultareventoporusuario = "?usuario2=" + usuario2;
                listaNueva = this.GetAsCollection(consultareventoporusuario);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia con el usuario");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }


        public void regresarObjeto(int id)
        {
            try
            {
                Eventos eventosTemp = this.Get(id.ToString());
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
            ArrayList listaNueva = new ArrayList();
            try
            {
                
                List<Eventos> todoseventos = this.GetAsCollection();

                if (listaNueva == null)
                    Error.ingresarError(2, "No se econtro ningun evento registrada");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarEventos()
        {
            List<Eventos> listaNueva = null;
            try
            {
                Eventos clas = new Eventos();
                string consulta = "?eventos=" + this.id.ToString();
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
