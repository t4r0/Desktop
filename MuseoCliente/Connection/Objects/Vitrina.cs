using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections;

namespace MuseoCliente.Connection.Objects
{
    class Vitrina:ResourceObject<Vitrina>
    {
        [JsonProperty]
        public String numero { get; set; }
        [JsonProperty]
        public int sala { get; set; }

        public Vitrina()
            : base("/v1/vitrinas/")
        {
        }

        public void guardar()
        {
            try 
            {
                this.Create();
            }
            catch ( Exception e )
            {
                if(e.Source != null)
                {
                    Error.ingresarError( 3, "No se ha guardado la Informacion en la base de datos" );
                }
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
                if (e.Source != null)
                {
                    Error.ingresarError(3, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

        public ArrayList listarPorNumero( string numero )
        {
            ArrayList lista = null;
            ArrayList listaNueva = null;
            try
            {
                lista = this.GetAsCollection();
                foreach( Vitrina vitrina in lista )
                {
                    if( vitrina.numero == numero )
                    {
                        listaNueva.Add( vitrina );
                    }
                }
                if(listaNueva == null)
                {
                Error.ingresarError( 2, "no se encontraron vitrinas con numero " + numero );
                }
            }
            catch (Exception e)
            {
                Error.ingresarError( 2, "no se encontraron vitrinas con numero " + numero );
            }
            return listaNueva;
        }

        public ArrayList listarPorSala(int sala)
        {
            ArrayList lista = null;
            ArrayList listaNueva = null;
            try
            {
                lista = this.GetAsCollection();
                foreach (Vitrina vitrina in lista)
                {
                    if (vitrina.sala == sala)
                    {
                        listaNueva.Add(vitrina);
                    }
                }
                if (listaNueva == null)
                {
                    Error.ingresarError(2, "no se encontraron vitrinas con sala " + sala);
                }
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron vitrinas con numero " + sala );
            }
            return listaNueva;
        }

    }
}
