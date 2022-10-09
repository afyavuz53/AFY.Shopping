using Afy.Shopping.BLL.Abstract;
using Afy.Shopping.DAL.Abstract;
using Afy.Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.BLL.Concrete
{
    internal class ProductManager : IProductManager
    {
        IProductService _service;
        public ProductManager(IProductService productService)
        {
            _service = productService ?? throw new ArgumentNullException(nameof(productService));
        }
        public Task<ICollection<Product>> GetAll(Expression<Func<Product, bool>> filter = null!)
        {
            if (filter == null)
                return _service.GetAsync();
            else
                return _service.GetAsync(filter);
        }
    }
}
