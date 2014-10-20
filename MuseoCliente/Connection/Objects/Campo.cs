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
    public class Campo : ResourceObject<Campo>
    {
         public Campo():base("v1/categoria/")
        {

        }

         [JsonProperty]
         public int campoEstructura { get; set; }

         [JsonProperty]
         public int tipoCampo { get; set; }

         [JsonProperty]
         public string valorTexto { get; set; }

         [JsonProperty]
         public string valorTextoLargo { get; set; }

         [JsonProperty]
         public DateTime valorFecha { get; set; }

         [JsonProperty]
         public float valorNumerico { get; set; }

         [JsonProperty]
         public int valorRadio { get; set; }

         public void guardar()
         {
             try
             {
                 this.Create();
             }
             catch (Exception e)
             {
                 if (e.Source != null)
                 {
                     Error.ingresarError(3, "No se ha guardado la Informacion en la base de datos");
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

         public ArrayList consultarTipoCampo(int tipoCampo)
         {
             List<Campo> listaNueva = new List<Campo>();
             try
             {
                 List<Campo> todosCampos = this.GetAsCollection();
                 foreach(Campo campo in todosCampos)
                 {
                     if (campo.tipoCampo == tipoCampo)
                         listaNueva.Add(campo);
                 }
                 if (listaNueva == null)
                     Error.ingresarError(2, "no se encontraron coincidencias con tipo de campo: " + tipoCampo);
             }
             catch (Exception e)
             {
                 Error.ingresarError(2, "no se encontraron coincidencias con tipo de campo: " + tipoCampo);
             }
             return new ArrayList(listaNueva);
         }

         public ArrayList consultarCampoEstructura(int campoEstructura)
         {
             List<Campo> listaNueva = new List<Campo>();
             try
             {
                 List<Campo> todosCampos = this.GetAsCollection();
                 foreach (Campo campo in todosCampos)
                 {
                     if (campo.campoEstructura == campoEstructura)
                         listaNueva.Add(campo);
                 }
                 if (listaNueva == null)
                     Error.ingresarError(2, "no se encontraron coincidencias con campoEstructura: " + campoEstructura);
             }
             catch (Exception e)
             {
                 Error.ingresarError(2, "no se encontraron coincidencias con campoEstructura: " + campoEstructura);
             }
             return new ArrayList(listaNueva);
         }

         public ArrayList consultarValorTexto(string valorTexto)
         {
             List<Campo> listaNueva = new List<Campo>();
             try
             {
                 List<Campo> todosCampos = this.GetAsCollection();
                 foreach (Campo campo in todosCampos)
                 {
                     if (campo.valorTexto.Contains(valorTexto))
                         listaNueva.Add(campo);
                 }
                 if (listaNueva == null)
                     Error.ingresarError(2, "no se encontraron coincidencias con valorTexto: " + valorTexto);
             }
             catch (Exception e)
             {
                 Error.ingresarError(2, "no se encontraron coincidencias con valorTexto: " + valorTexto);
             }
             return new ArrayList(listaNueva);
         }

         public ArrayList consultarValorTextoLargo(string valorTextoLargo)
         {
             List<Campo> listaNueva = new List<Campo>();
             try
             {
                 List<Campo> todosCampos = this.GetAsCollection();
                 foreach (Campo campo in todosCampos)
                 {
                     if (campo.valorTextoLargo.Contains(valorTextoLargo))
                         listaNueva.Add(campo);
                 }
                 if (listaNueva == null)
                     Error.ingresarError(2, "no se encontraron coincidencias con valorTextoLargo: " + valorTextoLargo);
             }
             catch (Exception e)
             {
                 Error.ingresarError(2, "no se encontraron coincidencias con valorTextoLargo: " + valorTextoLargo);
             }
             return new ArrayList(listaNueva);
         }

         public ArrayList consultarValorFecha(DateTime valorFecha)
         {
             List<Campo> listaNueva = new List<Campo>();
             try
             {
                 List<Campo> todosCampos = this.GetAsCollection();
                 foreach (Campo campo in todosCampos)
                 {
                     if (campo.valorFecha.Date == valorFecha.Date)
                         listaNueva.Add(campo);
                 }
                 if (listaNueva == null)
                     Error.ingresarError(2, "no se encontraron coincidencias con fecha: " + valorFecha.Date);
             }
             catch (Exception e)
             {
                 Error.ingresarError(2, "no se encontraron coincidencias con fecha: " + valorFecha.Date);
             }
             return new ArrayList(listaNueva);
         }

         public ArrayList consultarValorNumerico(float valorNumerico)
         {
             List<Campo> listaNueva = new List<Campo>();
             try
             {
                 List<Campo> todosCampos = this.GetAsCollection();
                 foreach (Campo campo in todosCampos)
                 {
                     if (campo.valorNumerico == valorNumerico)
                         listaNueva.Add(campo);
                 }
                 if (listaNueva == null)
                     Error.ingresarError(2, "no se encontraron coincidencias con valorNumerico: " + valorNumerico);
             }
             catch (Exception e)
             {
                 Error.ingresarError(2, "no se encontraron coincidencias con valorNumerico: " + valorNumerico);
             }
             return new ArrayList(listaNueva);
         }

         public ArrayList consultarValorRadio(int valorRadio)
         {
             List<Campo> listaNueva = new List<Campo>();
             try
             {
                 List<Campo> todosCampos = this.GetAsCollection();
                 foreach (Campo campo in todosCampos)
                 {
                     if (campo.valorRadio == valorRadio)
                         listaNueva.Add(campo);
                 }
                 if (listaNueva == null)
                     Error.ingresarError(2, "no se encontraron coincidencias con valorRadio: " + valorRadio);
             }
             catch (Exception e)
             {
                 Error.ingresarError(2, "no se encontraron coincidencias con valorRadio: " + valorRadio);
             }
             return new ArrayList(listaNueva);
         }
    }
}
