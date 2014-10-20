﻿using System;
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

        public Vitrina() : base("/v1/vitrinas/")
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
                    Error.ingresarError(4, "No se ha modificado la Informacion en la base de datos");
                }
            }
        }

        public ArrayList consultarNumero( string numero )
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Vitrina> lista = (ICollection<Vitrina>)this.GetAsCollection();
                var Vitrinas = from vitrina in lista where vitrina.numero == numero select vitrina;
                listaNueva.AddRange((ICollection)Vitrinas);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con el numero: " + numero);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con el numero: " + numero);
            }
            return new ArrayList(listaNueva);
        }

        public ArrayList consultarSala(int sala)
        {
            ArrayList listaNueva = null;
            try
            {
                ICollection<Vitrina> lista = (ICollection<Vitrina>)this.GetAsCollection();
                var Vitrinas = from vitrina in lista where vitrina.sala == sala select vitrina;
                listaNueva.AddRange((ICollection)Vitrinas);
                if (listaNueva == null)
                    Error.ingresarError(2, "no se encontraron coincidencias con sala: " + sala);
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "no se encontraron coincidencias con sala: " + sala);
            }
            return new ArrayList(listaNueva);
        }

    }
}
