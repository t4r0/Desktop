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
        private string server="http://104.131.99.190";// al final no lleva el slash para no crear dos veces el mismo

        public string Server{
            get{return server;}
            set{server=value;}
        }

        private string token = "93cfa0141a9ee3790728c90838089024a2006e7a";

        public string BaseUri
        {
            get;
            set;
        }

        public Connector()
        {
        }

        public Connector(string resourceUri)
        {
            this.BaseUri = resourceUri;
        }

        public Connector(string server, string accessToken)
        {
            this.Server = server;
            this.token = accessToken;          
        }

        public void delete(string id)
        {
            HttpClient client = CreateRequest();
            string absoluteUri = server + BaseUri+ id+"/";
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Delete, absoluteUri);
            reqMessage.Content = new StringContent("", Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.SendAsync(reqMessage).Result;
            string responseContent = message.Content.ReadAsStringAsync().Result;
            if (message.StatusCode == HttpStatusCode.NoContent || message.StatusCode == HttpStatusCode.OK)
                return ;
            else
            {
                Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                if (error.Keys.Contains("error"))
                    throw new Exception(error["error"]);
                if (error.Keys.Contains("error_message"))
                    throw new Exception(error["error_message"]);
            }
        }

        public HttpClient CreateRequest()
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "oAuth " + token);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            return client;
        }

        public string fetch()
        {
            HttpClient client = CreateRequest();
            HttpResponseMessage message = client.GetAsync(server + BaseUri).Result;
            string content = message.Content.ReadAsStringAsync().Result;
            if(message.StatusCode == HttpStatusCode.OK)
                return content;
            Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string,string>>(content);
            if(error.Keys.Contains("error"))
                throw new Exception(error["error"]);
            if (error.Keys.Contains("error_message"))
                throw new Exception(error["error_message"]);
            return "";
        }

        public string fetch(int offset, int limit = 20)
        {
            HttpClient client = CreateRequest();
            string absoluteUri = server + BaseUri;
            HttpResponseMessage message = client.GetAsync(absoluteUri+"?offset="+offset+"&limit="+limit).Result;
            string content = message.Content.ReadAsStringAsync().Result;
            if (message.StatusCode == HttpStatusCode.OK)
                return content;
            Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            if (error.Keys.Contains("error"))
                throw new Exception(error["error"]);
            if (error.Keys.Contains("error_message"))
                throw new Exception(error["error_message"]);
            return "";
        }

        public string fetch(string direccion)
        {
            HttpClient client = CreateRequest();
            string absoluteUri = server + BaseUri;
            HttpResponseMessage message = client.GetAsync(absoluteUri + direccion).Result;
            string content = message.Content.ReadAsStringAsync().Result;
            if (message.StatusCode == HttpStatusCode.OK)
                return content;
            Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string, string>>(content);
            if (error.Keys.Contains("error"))
                throw new Exception(error["error"]);
            if (error.Keys.Contains("error_message"))
                throw new Exception(error["error_message"]);
            return "";
        }

        public string create(string content)
        {
            HttpClient client = CreateRequest();
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Post, server + BaseUri);
            reqMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.SendAsync(reqMessage).Result;
            string responseContent = message.Content.ReadAsStringAsync().Result;
            if (message.StatusCode == HttpStatusCode.Created || message.StatusCode == HttpStatusCode.OK)
                return responseContent;
            Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
            if (error.Keys.Contains("error"))
                throw new Exception(error["error"]);
            if (error.Keys.Contains("error_message"))
                throw new Exception(error["error_message"]);
            return "";
        }

        public void edit(string id, string content)
        {
            HttpClient client = CreateRequest();
            HttpRequestMessage reqMessage = new HttpRequestMessage(HttpMethod.Put, server + BaseUri + id +"/");
            reqMessage.Content = new StringContent(content, Encoding.UTF8, "application/json");
            HttpResponseMessage message = client.SendAsync(reqMessage).Result;
            string responseContent = message.Content.ReadAsStringAsync().Result;
            if (message.StatusCode == HttpStatusCode.NoContent || message.StatusCode == HttpStatusCode.OK)
                return;
            else
            {
                Dictionary<string, string> error = JsonConvert.DeserializeObject<Dictionary<string, string>>(responseContent);
                if (error.Keys.Contains("error"))
                    throw new Exception(error["error"]);
                if (error.Keys.Contains("error_message"))
                    throw new Exception(error["error_message"]);
            }
        }

        public string fetch(Dictionary<string, string> args)
        {
            string concatParams = "?";
            foreach (string key in args.Keys)
            {
                concatParams += key + "=" + args[key] + "&";
            }
            concatParams= concatParams.Substring(0, concatParams.Length - 1);
            return fetch(concatParams);
        }
    }
}
