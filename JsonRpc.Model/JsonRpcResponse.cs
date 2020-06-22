namespace JsonRpcClient.JsonRpc.Model
{
    public class JsonRpcResponse<TResult, TErrorData>
    {
        public string jsonrpc { get; set; }

        public string id { get; set; }
        public TResult result { get; set; }
        public JsonRpcResponseError<TErrorData> error { get; set; }
    }

    public class JsonRpcResponseError<T>
    {
        public int code { get; set; }
        public string message { get; set; }
        public T data { get; set; }
    }
}