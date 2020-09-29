using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.DependencyInjection.Extensions;

using Data;
using Data.Abstractions.Interfaces;

namespace WebApplication1
{
    public class Startup
    {
        private static string ApiTitle = "DocSys Generation";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //ConfigureDevelop
        public IConfiguration Configuration { get; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddOptions();
            //services.ConfigureOptions(Configuration);
            services.Configure<ConnectionConfig>(Configuration.GetSection("DbSettings"))
              .AddTransient(cfg => cfg.GetService<IOptions<ConnectionConfig>>().Value);

            services.TryAddSingleton<ISqlPolicyRegistry, SqlPolicyRegistry>();
            services.TryAddScoped<SqlDataConnection>();
            services.AddTransient<IDbContext, DbContext>();


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, Microsoft.Extensions.Hosting.IHostApplicationLifetime appLifetime)
        {
        }
    }
}

