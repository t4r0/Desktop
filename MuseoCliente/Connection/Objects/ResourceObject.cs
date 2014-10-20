using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public  class ResourceObject<T> : IResourceObject<T>
    {

        [JsonIgnore]
        Connector conector = new Connector();

        public ResourceObject(string resourceUri)
        {
            conector.ResourceUri = resourceUri;
        }

        public void Save(string id)
        {            
            string content = JsonConvert.SerializeObject(this);
            conector.edit(id, content);
        }

        public void Create()
        {
            string content = JsonConvert.SerializeObject(this);
            conector.create(content);
        }

        public T Get(string id)
        {
            conector.ResourceUri += '/' + id + '/';
            string content=conector.fetch();
            return JsonConvert.DeserializeObject<T>(content);
        }

        public  List<T> GetAsCollection()
        {
            string content = conector.fetch();
            List<T> list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }
    }
}
