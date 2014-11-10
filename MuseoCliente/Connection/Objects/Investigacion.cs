using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class Investigacion : ResourceObject<Investigacion>
    {
        public Investigacion()
            : base( "/api/v1/investigaciones/" )
        {
            links = new List<LinkInvestigacion>();
            linkNuevos = new List<LinkInvestigacion>();
            piezas = new List<Dictionary<string, string>>();
        }

        [JsonProperty]
        public string editor { get; set; }

        [JsonProperty]
        public string titulo { get; set; }

        [JsonProperty]
        public string contenido { get; set; }

        [JsonProperty]
        public string resumen { get; set; }

        [JsonProperty]
        public int autor { get; set; }

        [JsonProperty]
        public DateTime fecha { get; set; }

        [JsonProperty]
        public bool publicado { get; set; }

        [JsonProperty]
        public List<LinkInvestigacion> links{ get; set; }

        [JsonProperty]
        public List<Dictionary<string,string>> piezas { get; set; }

        private List<LinkInvestigacion> linkNuevos;

        private void igualarLista(List<LinkInvestigacion> nuevo, List<LinkInvestigacion> viejo)
        {
            nuevo.Clear();
            foreach (LinkInvestigacion temp in viejo)
            {
                temp.investigacion = this.id;
                nuevo.Add(temp);
            }
            viejo.Clear();
        }

        public void guardar()
        {
            try
            {
                igualarLista(linkNuevos, links);
                this.id = Deserialize(this.Create()).id;
                igualarLista(links, linkNuevos);
                this.Save(this.id.ToString());
                
            }
            catch( Exception e )
            {
                if( e.Source != null )
                {
                    string error = e.Source; // para ver el nombre del error.
                    Error.ingresarError( 3, "No se ha guardado en la Informacion en la base de datos "+e.Message );
                }
            }
        }

        public void eliminar()
        {
            try
            {
                this.del();
            }
            catch (Exception e)
            {
                Error.ingresarError(3, "No se ha guardado en la Informacion en la base de datos " + e.Message);
            }
        }

        private void elminarLinks()
        {
            List<LinkInvestigacion> lista = this.regresarLinkInvestigacion().ToList<LinkInvestigacion>();
            foreach (LinkInvestigacion temp in lista)
                temp.eliminar();
        }

        public void modificar()
        {
            try
            {
                elminarLinks();
                foreach (LinkInvestigacion temp in links)
                    temp.investigacion = this.id;
                this.Save( this.id.ToString() );
            }
            catch( Exception e )
            {
                if( e.Source != null )
                {
                    string error = e.Source;// para ver el nombre del error
                    Error.ingresarError( 3, "No se ha modifico en la Informacion en la base de datos " +e.Message );
                }
            }
        }


        public ArrayList buscarTitulo( String titulo )
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( "?titulo__icontains=" + titulo ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList consultaAutor( String autor )
        {
            ArrayList listaNueva = null;

            try
            {
                listaNueva = new ArrayList( this.GetAsCollection( "?autor" + autor ) );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "No se encontro nombre similares" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return new ArrayList( listaNueva );
        }

        public ArrayList regresarLinkInvestigacion()
        {
            ArrayList listaNueva = null;
            try
            {
                LinkInvestigacion LinkInvestigacion = new LinkInvestigacion();
                listaNueva = new ArrayList(LinkInvestigacion.GetAsCollection("?investigacion=" + this.id));
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "no se encontraron coincidencias" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public ArrayList regresarTodo()
        {
            ArrayList listaNueva = null;
            try
            {
                listaNueva = new ArrayList( this.fetchAll() );
            }
            catch( Exception e )
            {
                Error.ingresarError( 2, "tabla vacia" );
            }
            if( listaNueva == null )
            {
                Error.ingresarError( 2, "No se encontraron coincidencias" );
                return null;
            }
            return listaNueva;
        }

        public void regresarObjeto( int id )
        {
            this.resource_uri = this.resource_uri + id + "/";
            Investigacion Temp = this.Get();
            if( Temp == null )
            {
                Error.ingresarError( 2, "No se encontro coincidencia" );
                return;
            }
            this.id = Temp.id;
            this.resource_uri = Temp.resource_uri;
            this.autor = Temp.autor;
            this.contenido = Temp.contenido;
            this.editor = Temp.editor;
            this.fecha = Temp.fecha;
            this.publicado = Temp.publicado;
            this.resumen = Temp.resumen;
            this.titulo = Temp.titulo;
            this.links = Temp.links;
            this.piezas = Temp.piezas;
            igualarLista(this.links, Temp.links);

            
        }

        public ArrayList regresarPiezas()
        {
            List<Pieza> lista = new List<Pieza>();
            try
            {
                foreach (Dictionary<string, string> temp in piezas)
                {
                    Pieza pieza = new Pieza();
                    pieza.regresarObjeto(temp["codigo"]);
                    lista.Add(pieza);
                }
                /*
                    foreach (string hola in temp.Keys)
                    {
                        pieza = new Pieza();
                        pieza.regresarObjeto(temp[hola]);
                        lista.Add(pieza);
                    }*/
            }
            catch (Exception e)
            {
                Error.ingresarError(2, "No existen piezas para la investigacion "+e.Message);
                return null;
            }

            return (new ArrayList(lista));
        }

        public ArrayList regresarLinks()
        {
            if (piezas.Count <= 0)
            {
                Error.ingresarError(2, "No existen piezas para la investigacion " );
                return null;
            }
            return (new ArrayList(piezas));  
        }

        public void ingresarLinks(List<LinkInvestigacion> link)
        {
            links.Clear();
            links = link;
             
        }
        public void ingresarLinks(string link)
        {
            LinkInvestigacion tempLink = new LinkInvestigacion();
            tempLink.link = link;
            links.Add(tempLink);

        }

        public void ingresarPiezas(List<Pieza> codigo)
        {
            piezas.Clear();
            Dictionary<string, string> diccionario = null;
            foreach (Pieza temp in codigo)
            {
                diccionario = new Dictionary<string, string>();
                diccionario["codigo"] = temp.codigo;
                piezas.Add(diccionario);
            }
        }
        public void ingresarPiezas(Pieza pieza)
        {
            Dictionary<string, string> diccionario = new Dictionary<string,string>();
            diccionario["codigo"] = pieza.codigo;
            piezas.Add(diccionario);
        }

    }
}
