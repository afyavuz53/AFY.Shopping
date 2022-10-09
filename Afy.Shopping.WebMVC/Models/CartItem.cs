namespace Afy.Shopping.WebMVC.Models
{
    public class CartItem
    {
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public string? ProductId { get; set; }
        public string? ProductName { get; set; }
    }
}
