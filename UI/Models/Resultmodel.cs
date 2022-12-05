namespace UI.Models
{
    public class Resultmodel<T>
    {
        public T? Data { get; set; }

        public List<T>? DataList { get; set; }

        public string? Message { get; set; }

        public int StatusCode { get; set; }
    }
}
