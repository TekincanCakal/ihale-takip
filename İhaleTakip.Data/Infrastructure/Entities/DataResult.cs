namespace İhaleTakip.Data.Infrastructure.Entities
{
    public class DataResult<T>
    {
        public DataResult(bool isSucced, T data, string message)
        {
            IsSucced = isSucced;
            Message = message;
            Data = data;
        }

        public bool IsSucced { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
