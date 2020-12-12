namespace Web.API
{
    public class Response<TData> : VoidResponse
    {
        public TData Data { get; }
    }
}