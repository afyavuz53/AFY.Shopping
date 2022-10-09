using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.Model.Entities.Basket
{
    public class ShoppingCartItem
    {
        /// <summary>
        /// Adet
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Fiyat
        /// </summary>
        public decimal Price { get; set; }
        /// <summary>
        /// Ürün id
        /// </summary>
        public string? ProductId { get; set; }
        /// <summary>
        /// Ürün Adı
        /// </summary>
        public string? ProductName { get; set; }
    }
}
