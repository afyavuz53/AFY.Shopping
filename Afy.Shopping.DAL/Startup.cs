using Afy.Shopping.DAL.Abstract;
using Afy.Shopping.DAL.Concrete;
using Afy.Shopping.Model.Settings;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.DAL
{
    public static class StartUp
    {
        public static IServiceCollection AddDataAccessLayer(this IServiceCollection services)
        {
            return services.AddSingleton<IProductService, ProductService>();
        }
    }
}
