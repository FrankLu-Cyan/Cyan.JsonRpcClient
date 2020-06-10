using JsonRpcClient.JsonRpc.Model;
using RestSharp;
using System;
using System.Net;

namespace JsonRpcClient
{
    public class JsonRpcClient
    {
        private RestClient Client;
        public int TimeOut { get; set; } = 1000;

        public JsonRpcClient(string url)
        {
            var cookieContainer = new CookieContainer();
            Client = new RestClient(url) { CookieContainer = cookieContainer, Timeout = TimeOut };
        }

        public TResponse Call<TResponse, TRequest>(string resource, JsonRpcRequest<TRequest> jsonRequest)
            where TResponse : new()
            where TRequest : new()
        {
            var request = new RestRequest(resource);
            request.AddJsonBody(jsonRequest.@params);

            var result = Client.Post<TResponse>(request);

            return result.Data;
        }
    }
}