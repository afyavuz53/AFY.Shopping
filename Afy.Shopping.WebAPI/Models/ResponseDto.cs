namespace Afy.Shopping.WebAPI.Models
{
    /// <summary>
    /// Cevap
    /// </summary>
    public class ResponseDto
    {
        /// <summary>
        /// Cevap durumu
        /// </summary>
        public bool status { get; set; }
        /// <summary>
        /// Var ise hata mesajı
        /// </summary>
        public string? message { get; set; }
        /// <summary>
        /// Sayfa numarası
        /// </summary>
        public int page { get; set; }
        /// <summary>
        /// Sayfa büyüklüğü
        /// </summary>
        public int pagesize { get; set; }
        /// <summary>
        /// Toplam ürün sayısı
        /// </summary>
        public int totalCount { get; set; }
        /// <summary>
        /// Toplam sayfa sayısı
        /// </summary>
        public int totalPage { get; set; }
        public List<object> items { get; set; }=new List<object> { };
    }
}
