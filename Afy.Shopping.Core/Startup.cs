using Afy.Shopping.Core.Common;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Afy.Shopping.Core
{
    public static class Startup
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            return services.AddServices();
        }
    }
}
