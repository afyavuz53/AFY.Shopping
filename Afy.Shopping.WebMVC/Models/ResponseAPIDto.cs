namespace Afy.Shopping.WebMVC.Models
{
    public class ResponseAPIDto<T>
    {
        public bool status { get; set; }
        public string? message { get; set; }
        public int page { get; set; }
        public int pagesize { get; set; }
        public int totalCount { get; set; }
        public int totalPage { get; set; }
        public List<T> items { get; set; } = new List<T> { };
    }
}
