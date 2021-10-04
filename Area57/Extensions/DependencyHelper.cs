using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Settings.Configuration;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using Area57.Services;

namespace Common.Extensions
{
    public static class DependencyHelper
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<ItemService, ItemService>();
            return services;
        }
    }
}
