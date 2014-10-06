using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MuseoCliente.Connection
{
    public class Connector
    {
        private string server="http://localhost:8000/";

        public string Server{
            get{return server;}
            set{server=value;}
        }

        private string token = "82ca4127c5bdac3e61aacd47bda9bf7d32e4e4d6";

        public string ResourceUri
        {
            get;
            set;
        }

        public Connector()
        {
        }

        public Connector(string resourceUri)
        {
            this.ResourceUri = resourceUri;
        }

        public Connector(string server, string accessToken)
        {
            this.Server = server;
            this.token = accessToken;          
        }

        public HttpClient CreateRequest()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(server);
            client.DefaultRequestHeaders.Add("Authorization", "oAuth " + token);
            return client;
        }

        public string fetch()
        {
            HttpClient client = CreateRequest();
            string content = client.GetStringAsync(client.BaseAddress.AbsoluteUri + ResourceUri).Result;
            return content;
        }

        public void create(string content)
        {
            HttpClient client = CreateRequest();
            client.PostAsync(client.BaseAddress.AbsoluteUri + ResourceUri, new StringContent(content));
        }

        public void edit(string id, string content)
        {
            HttpClient client = CreateRequest();           
            client.PutAsync(client.BaseAddress.AbsoluteUri + ResourceUri + "/" + id + "/", new StringContent(content));
        }

    }
}
