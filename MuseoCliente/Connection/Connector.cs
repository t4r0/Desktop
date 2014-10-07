using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

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
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public string fetch()
        {
            HttpClient client = CreateRequest();
            HttpResponseMessage message = client.GetAsync(client.BaseAddress.AbsoluteUri + ResourceUri).Result;
            string content = message.Content.ReadAsStringAsync().Result;
            if(message.StatusCode == HttpStatusCode.OK)
                return content;
            Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string,string>>(content);
            throw new Exception(error["error"]);
        }

        public void create(string content)
        {
            HttpClient client = CreateRequest();
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, ResourceUri);
            reqMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.SendAsync(reqMessage).Result;
            string responseContent = message.Content.ReadAsStringAsync().Result;
            if (message.StatusCode != HttpStatusCode.OK)
            {
                Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                throw new Exception(error["error"]);
            }
        }

        public void edit(string id, string content)
        {
            HttpClient client = CreateRequest();           
            HttpResponseMessage message =client.PutAsync(client.BaseAddress.AbsoluteUri + ResourceUri + "/" + id + "/", new StringContent(content)).Result;
            string responseContent = message.Content.ReadAsStringAsync().Result;
            if (message.StatusCode != HttpStatusCode.Accepted)
            {
                Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                throw new Exception(error["error"]);
            }
        }

    }
}
