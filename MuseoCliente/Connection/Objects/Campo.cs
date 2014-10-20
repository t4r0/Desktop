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
             ArrayList listaNueva = null;
             try
             {
                 ICollection<Campo> lista = (ICollection<Campo>)this.GetAsCollection();
                 var Campos = from campo in lista where campo.tipoCampo == tipoCampo select campo;
                 listaNueva.AddRange((ICollection)Campos);
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
             ArrayList listaNueva = null;
             try
             {
                 ICollection<Campo> lista = (ICollection<Campo>)this.GetAsCollection();
                 var Campos = from campo in lista where campo.campoEstructura == campoEstructura select campo;
                 listaNueva.AddRange((ICollection)Campos);
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
             ArrayList listaNueva = null;
             try
             {
                 ICollection<Campo> lista = (ICollection<Campo>)this.GetAsCollection();
                 var Campos = from campo in lista where campo.valorTexto == valorTexto select campo;
                 listaNueva.AddRange((ICollection)Campos);
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
             ArrayList listaNueva = null;
             try
             {
                 ICollection<Campo> lista = (ICollection<Campo>)this.GetAsCollection();
                 var Campos = from campo in lista where campo.valorTextoLargo == valorTextoLargo select campo;
                 listaNueva.AddRange((ICollection)Campos);
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
             ArrayList listaNueva = null;
             try
             {
                 ICollection<Campo> lista = (ICollection<Campo>)this.GetAsCollection();
                 var Campos = from campo in lista where campo.valorFecha.Date == valorFecha.Date select campo;
                 listaNueva.AddRange((ICollection)Campos);
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
             ArrayList listaNueva = null;
             try
             {
                 ICollection<Campo> lista = (ICollection<Campo>)this.GetAsCollection();
                 var Campos = from campo in lista where campo.valorNumerico == valorNumerico select campo;
                 listaNueva.AddRange((ICollection)Campos);
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
             ArrayList listaNueva = null;
             try
             {
                 ICollection<Campo> lista = (ICollection<Campo>)this.GetAsCollection();
                 var Campos = from campo in lista where campo.valorRadio == valorRadio select campo;
                 listaNueva.AddRange((ICollection)Campos);
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
