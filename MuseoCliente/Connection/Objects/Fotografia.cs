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
        public Int16 tipo { get; set; }  // ya
        [JsonProperty]
        public String ruta { get; set; }
        [JsonProperty]
        public Boolean perfil { set; get; } // ya

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

                List<Fotografia> todasFotografia = this.GetAsCollection();
                foreach (Fotografia hol in todasFotografia)
                {
                    if (hol.tipo == tipo)
                        listaNueva.Add(hol);
                }

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

                List<Fotografia> todasFotografia = this.GetAsCollection();
                foreach (Fotografia hol in todasFotografia)
                {
                    if (hol.perfil == perfil)
                        listaNueva.Add(hol);
                }

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro nombre similares");
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro nombre similares");
            }
            return new ArrayList(listaNueva);
        }
                
        public ArrayList consultapormantenimiento(int mantenimiento)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Fotografia> listaNueva = null;
            try
            {

                string mantenimiento2 = mantenimiento.ToString();
                //fecha.Date.ToString();
                string consultapormantenimiento = "?mantenimiento=" + mantenimiento2;
                listaNueva = this.GetAsCollection(consultapormantenimiento);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por mantenimiento");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList consultaporpieza(int pieza)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Fotografia> listaNueva = null;
            try
            {

                string pieza2 = pieza.ToString();
                //fecha.Date.ToString();
                string consultapormantenimiento = "?pieza=" + pieza2;
                listaNueva = this.GetAsCollection(consultapormantenimiento);

                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia por la busqueda por pieza en fotografia");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }


        public ArrayList consultaporruta(string afiche)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            List<Fotografia> listaNueva = null;
            try
            {
                string consultaporruta = "?ruta=" + ruta;
                listaNueva = this.GetAsCollection(consultaporruta);


                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontro ninguna coincidencia con la ruta");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList consultarporperfil(bool perfil)
        {
            List<Fotografia> listaNueva = null;
            try
            {
                string consultar = "?perfil=" + perfil.ToString();
                listaNueva = this.GetAsCollection(consultar);
                if (listaNueva == null)
                    Error.ingresarError(2, "No se encontraron perfiles similares");
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

                List<Fotografia> todasFichas = this.GetAsCollection();

                if (listaNueva == null)
                    Error.ingresarError(2, "No se econtro ninguna Fotografia registrada");
            }
            catch (Exception e)
            {
                Error.ingresarError(5, "Ha ocurrido un Error en la Coneccion Porfavor Verifique su conecciona a Internet");
            }

            return new ArrayList(listaNueva);
        }

        public ArrayList regresarClasificaciones()
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                Clasificacion clas = new Clasificacion();
                string consulta = "?fotografia=" + this.id.ToString();
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
