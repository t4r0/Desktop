using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public  class ResourceObject<T> 
    {

        [JsonIgnore]
        Connector conector = new Connector();

        [JsonProperty]
        public String resource_uri { get; set; }

        [JsonProperty]
        public int id { get; set; }

        protected ResourceObject(string resourceUri)
        {
            conector.BaseUri = resourceUri;
        }

        //protected void setResourceUri(string resourceUri)
        //{
        //    conector.BaseUri = resourceUri;
        //}

        protected void Save(string id)
        {            
            string content = JsonConvert.SerializeObject(this);
            conector.edit(id, content);
        }

        protected void Create()
        {
            string content = JsonConvert.SerializeObject(this);
            conector.create(content);
        }

        protected T Get(string id)
        {
            conector.BaseUri += '/' + id + '/';
            string content=conector.fetch();
            return JsonConvert.DeserializeObject<T>(content);
        }

        protected List<T> GetAsCollection()
        {
            string content = conector.fetch();
            List<T> list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }

        protected List<T> GetAsCollection(string direccion)
        {
            string content = conector.fetch(direccion);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }
    }
}
