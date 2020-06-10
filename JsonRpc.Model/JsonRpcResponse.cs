using System;
using System.Collections.Generic;
using System.Text;

namespace JsonRpcClient.JsonRpc.Model
{
    public class JsonRpcResponse<T> where T : new()
    {
        public string jsonrpc { get; set; }

        public T result { get; set; }
        public string id { get; set; }
    }
}