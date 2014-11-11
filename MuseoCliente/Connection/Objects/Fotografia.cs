using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    public class Fotografia:ResourceObject<Fotografia>
    {
        [JsonProperty]
        public int mantenimiento { get; set; }
        [JsonProperty]
        public string pieza { get; set; }
        [JsonProperty]
        public Int16 tipo { get; set; }  // ya
        [JsonProperty]
        public String ruta { get; set; }
        [JsonProperty]
        public Boolean perfil { set; get; } // ya

        public Fotografia()
            : base("/api/v1/fotografias/")
        {
        }

        public bool ShouldSerializemantenimiento()
        {
            return !(tipo == 1);
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

        public ArrayList consultartipo(Int16 tipo)
       //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            ArrayList listaNueva = null;
            try
            {

                string tipo2 = tipo.ToString();
                listaNueva = new ArrayList(this.GetAsCollection("?tipo__contains=" + tipo2));
               
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro tipo similares");
            }
            if (listaNueva == null)
            {
                string tipo3 = tipo.ToString();
                Error.ingresarError(2, "Nose encontro el tipo =" + tipo3);
                return null;
            }
            return new ArrayList(listaNueva);
        }

                

                    
        public ArrayList consultapormantenimiento(int mantenimiento)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            ArrayList listaNueva = null;
            try
            {

                string mantenimiento2 = mantenimiento.ToString();
                //fecha.Date.ToString();
                listaNueva = new ArrayList(this.GetAsCollection("?tipo__contains=" + mantenimiento2));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro mantenimiento similar");
            }
            if (listaNueva == null)
            {
                string mantenimiento3 = mantenimiento.ToString();
                Error.ingresarError(2, "Nose encontro el nombre =" + mantenimiento3);
                return null;
            }
            return new ArrayList(listaNueva);
        }                    
           

        public ArrayList consultaporpieza(int pieza)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            ArrayList listaNueva = null;
            try
            {
                string pieza2 = pieza.ToString();
                //fecha.Date.ToString();
                listaNueva = new ArrayList(this.GetAsCollection("?pieza__contains=" + pieza2));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro pieza similar");
            }
            if (listaNueva == null)
            {
                string pieza3 = pieza.ToString();
                Error.ingresarError(2, "Nose encontro el nombre =" + pieza3);
                return null;
            }
            return new ArrayList(listaNueva);
        }                    


        public ArrayList consultaporruta(string ruta)  //  la acabo de agregar segun la  la clase ficha  tercera agregada
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList(this.GetAsCollection("?ruta__contains=" + ruta));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro ruta similar");
            }
            if (listaNueva == null)
            {
                
                Error.ingresarError(2, "Nose encontro la ruta =" + ruta);
                return null;
            }
            return new ArrayList(listaNueva);
        }                    

        public ArrayList consultarporperfil(bool perfil)
        {
            ArrayList  listaNueva = null;
            try
            {
                string perfil2 = perfil.ToString(); 
                listaNueva = new ArrayList(this.GetAsCollection("?perfil__contains=" + perfil2));

            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No se encontro perfil similar");
            }
            if (listaNueva == null)
            {
                string perfil3 = perfil.ToString();
                Error.ingresarError(2, "Nose encontro la ruta =" + perfil3);
                return null;
            }
            return new ArrayList(listaNueva);
        }                    


        public ArrayList regresarTodos()
        {
            List<Fotografia> listaNueva = null;
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


        public ArrayList regresarClasificaciones()
        {
            List<Clasificacion> listaNueva = null;
            try
            {
                Clasificacion clas = new Clasificacion();
                string consulta = this.resource_uri + "?fotografia=" + this.id.ToString();
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

        public ArrayList regresarEventos()
        {
            List<Eventos> listaNueva = null;
            try
            {
                Eventos clas = new Eventos();
                string consulta = this.resource_uri + "?Fotografia=" + this.id.ToString();
                listaNueva = clas.GetAsCollection(consulta);

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


         public void regresarObjeto( int id )
        {
            this.resource_uri = this.resource_uri + id + "/";
            Fotografia Temp = this.Get();
            if( Temp == null )
            {
                Error.ingresarError( 2, "No se encontro coincidencia" );
                return;
            }
            this.id = Temp.id;
            this.mantenimiento = Temp.mantenimiento;
            this.tipo = Temp.tipo;
            this.ruta = Temp.ruta;
            this.perfil = Temp.perfil;
            this.pieza = Temp.pieza;
            this.resource_uri = Temp.resource_uri;
        }
    

    }
}
