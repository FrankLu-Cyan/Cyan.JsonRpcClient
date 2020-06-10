using System;
using System.Collections.Generic;
using System.Text;

namespace JsonRpcClient.JsonRpc.Model
{
    public class JsonRpcRequest<T> where T : new()
    {
        public string jsonrpc { get; set; }
        public string method { get; set; }
        public T @params { get; set; }
        public string id { get; set; }
    }
}