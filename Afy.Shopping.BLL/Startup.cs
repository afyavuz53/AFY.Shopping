using Afy.Shopping.BLL.Abstract;
using Afy.Shopping.BLL.Concrete;
using Afy.Shopping.DAL;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Afy.Shopping.BLL
{
    public static class Startup
    {
        public static IServiceCollection AddBusinessLogicLayer(this IServiceCollection services, IConfiguration config)
        {
            return services.AddDataAccessLayer()
            .AddStackExchangeRedisCache(options =>
            {
                options.Configuration = config.GetSection("CacheSettings:ConnectionString").Value;
            })
                .AddSingleton<IProductManager, ProductManager>()
                .AddScoped<IBasketManager, BasketManager>();
        }
    }
}