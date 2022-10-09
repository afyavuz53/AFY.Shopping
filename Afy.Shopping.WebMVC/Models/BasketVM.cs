namespace Afy.Shopping.WebMVC.Models
{
    public class BasketVM
    {
        public string? UserName { get; set; }
        public List<CartItem>? Items { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
