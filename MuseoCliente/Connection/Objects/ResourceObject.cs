using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.IO;

namespace MuseoCliente.Connection.Objects
{
    public class ResourceObject<T>
    {

        [JsonIgnore]
        Connector conector = new Connector();

        [JsonProperty]
        public String resource_uri { get; set; }

        [JsonProperty]
        public int id { get; set; }

        protected ResourceObject( string resourceUri )
        {
            conector.BaseUri = resourceUri;
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

        protected void Create()
        {
            conector.create(this.Serialize());
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

        protected T Get( string id )
        {
            conector.BaseUri += '/' + id + '/';
            string content = conector.fetch();
            return this.Deserialize(content);
        }

        protected List<T> GetAsCollection()
        {
            string content = conector.fetch();
            return this.DeserializeList(content);
        }

        public List<T> GetAsCollection( string direccion )
        {
            string content = conector.fetch( direccion );
            return this.DeserializeList(content);
        }
    }
}
