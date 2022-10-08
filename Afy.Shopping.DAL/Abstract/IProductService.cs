using Afy.Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.DAL.Abstract
{
    public interface IProductService
    {
        Task<ICollection<Product>> GetAsync();
        Task<ICollection<Product>> GetAsync(Expression<Func<Product, bool>> filter);
        Task<Product?> GetAsync(string id);
        Task CreateAsync(Product newProduct);
        Task UpdateAsync(string id, Product updatedProduct);
        Task RemoveAsync(string id);
    }
}
