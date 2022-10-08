using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.Model.Entities
{
    public class Product : BaseEntity
    {
        public string? title { get; set; }
        public double price { get; set; }
    }
}
