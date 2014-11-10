using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MuseoCliente.Connection.Objects
{
    public class ResourceObject<T>
    {
        [JsonIgnore]
        public string baseUri { get; set; }

        [JsonIgnore]
        public Connector conector = new Connector();

        [JsonProperty]
        public String resource_uri { get; set; }

        [JsonProperty]
        public int id { get; set; }

        protected ResourceObject( string resourceUri )
        {
            conector.BaseUri = resourceUri;
            this.baseUri = resourceUri;
            this.resource_uri = resourceUri;
        }

        //protected void setResourceUri(string resourceUri)
        //{
        //    conector.BaseUri = resourceUri;
        //}
        public bool ShouldSerializeid()
        {
            return false;
        }

        public bool ShouldSerializeresource_uri()
        {
            return false;
        }

        public void SerializeToFile(string path)
        {
             StreamWriter file=File.CreateText(path);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, this);
            file.Close();
        }

        public void SerializeListToFile(string path, List<T> list)
        {
            StreamWriter file = File.CreateText(path);
            JsonSerializer serializer = new JsonSerializer();
            serializer.Serialize(file, list);
            file.Close();
        }

        public T DeserializeFromFile(string path)
        {
            StreamReader file = File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            T obj = (T)serializer.Deserialize(file, typeof(T));
            file.Close();
            return obj;
        }

        public List<T> DeserializeListFromFile(string path)
        {
            StreamReader file = File.OpenText(path);
            JsonSerializer serializer = new JsonSerializer();
            List<T> list = (List<T>)serializer.Deserialize(file, typeof(List<T>));
            file.Close();
            return list;
        }
        protected void Save( string id )
        {
            conector.edit( id, this.Serialize() );
        }

        protected string Create()
        {
            return conector.create(this.Serialize());
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        public T Deserialize(string content)
        {
            return JsonConvert.DeserializeObject<T>(content);
        }

        public List<T> DeserializeList(string content)
        {
            return JsonConvert.DeserializeObject<List<T>>(content);
        }

        public List<T> fetchAll(int limit=20)
        {
            List<T> t = new List<T>(), temp;
            int offset = 0;
            while (true)
            {
                temp = DeserializeList(conector.fetch(offset, limit));
                t.AddRange(temp);
                if(temp.Count < limit)
                    break;
                offset += 20;
            }
            return t;
        }
        public  T Get( )
        {
            conector.BaseUri = this.resource_uri;
            string content = conector.fetch();
            conector.BaseUri = this.baseUri;
            return this.Deserialize(content);
        }

        public List<T> GetAsCollection()
        {
            string content = conector.fetch();
            return this.DeserializeList(content);
        }

        public List<T> GetAsCollection( string direccion )
        {
            string content = conector.fetch( direccion );
            return this.DeserializeList(content);
        }

        public void del()
        {
            conector.delete(this.id.ToString());
        }
    }
}
