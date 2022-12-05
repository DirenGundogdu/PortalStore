namespace API.Models
{
    public class ResultModel<T>
    {
        public T? Data { get; set; }

        public List<T>? DataList { get; set; }

        public string? Message { get; set; }

        public int StatusCode { get; set; }
    }
}
