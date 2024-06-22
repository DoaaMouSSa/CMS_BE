namespace cms_be.Models
{
    public class Response<T>
    {
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
        public T Payload { get; set; }
    }
}
