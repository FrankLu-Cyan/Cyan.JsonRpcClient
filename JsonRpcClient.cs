using JsonRpcClient.JsonRpc.Model;
using RestSharp;
using System.Net;

namespace JsonRpcClient
{
    public class JsonRpcClient
    {
        private RestClient Client;
        public CookieContainer CookieContainer { get; set; }
        public int TimeOut { get; set; } = 1000;
        public string jsonrpc { get; set; } = "2.0";
        public string method { get; set; }

        public JsonRpcClient(string url)
        {
            CookieContainer = new CookieContainer();
            Client = new RestClient(url) { CookieContainer = CookieContainer, Timeout = TimeOut };
        }

        public JsonRpcResponse<TResponse, TErrorData> Call<TResponse, TRequest, TErrorData>(TRequest jsonRpcParams, string resource, string method)
        {
            var request = new RestRequest(resource);
            var jsonRpcRequest = new JsonRpcRequest<TRequest> { jsonrpc = this.jsonrpc, method = method, @params = jsonRpcParams };

            request.AddJsonBody(jsonRpcRequest);

            var result = Client.Post<JsonRpcResponse<TResponse, TErrorData>>(request);

            return result.Data;
        }

        public JsonRpcResponse<TResponse, string> Call<TResponse, TRequest>(TRequest jsonRpcParams, string resource, string method)
        {
            return Call<TResponse, TRequest, string>(jsonRpcParams, resource, method);
        }
    }
}