using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MuseoCliente.Connection.Objects
{
    public class ResourceObject<T> : IResourceObject<T>
    {

        [JsonIgnore]
        Connector conector = new Connector();

        protected ResourceObject(string resourceUri)
        {
            conector.ResourceUri = resourceUri;
        }

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
            conector.ResourceUri += '/' + id + '/';
            string content=conector.fetch();
            return JsonConvert.DeserializeObject<T>(content);
        }

        protected List<T> GetAsCollection()
        {
            string content = conector.fetch();
            List<T> list = JsonConvert.DeserializeObject<List<T>>(content);
            return list;
        }
    }
}
