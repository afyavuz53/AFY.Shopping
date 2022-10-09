using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.Model.Entities.Basket
{
    /// <summary>
    /// Sepet
    /// </summary>
    public class ShoppingCart
    {
        /// <summary>
        /// Kullanıcı adı
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// Sepet Ögeleri
        /// </summary>
        public List<ShoppingCartItem> Items { get; set; } = new List<ShoppingCartItem>();
        public ShoppingCart(string userName)
        {
            UserName = userName;
        }
        /// <summary>
        /// Toplam Sepet Ücreti
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal totalprice = 0;
                foreach (ShoppingCartItem item in Items)
                {
                    totalprice += item.Price * item.Quantity;
                }
                return totalprice;
            }
        }
    }
}
