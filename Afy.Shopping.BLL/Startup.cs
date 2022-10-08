using Afy.Shopping.BLL.Abstract;
using Afy.Shopping.BLL.Concrete;
using Afy.Shopping.DAL;
using Microsoft.Extensions.DependencyInjection;

namespace Afy.Shopping.BLL
{
    public static class Startup
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services)
        {
            return services.AddDataAccessLayer()
                .AddSingleton<IProductManager, ProductManager>();
        }
    }
}