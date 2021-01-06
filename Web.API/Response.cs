namespace Web.API
{
    public class Response<TData> : VoidResponse
    {
        public Response(TData data)
        {
            Data = data;
        }

        public TData Data { get; }
    }
}