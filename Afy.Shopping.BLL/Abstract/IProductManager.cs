using Afy.Shopping.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.BLL.Abstract
{
    public interface IProductManager
    {
        Task<Product?> Get(string id);
        Task<ICollection<Product>> GetAll(Expression<Func<Product, bool>> filter = null!);
    }
}
