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
using Swashbuckle;
using Common.Models;
using Data;
using Data.Interfaces;
using Area57.Services;
using System.Resources;
using Application;
using Application.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace Area57
{
    public class Startup
    {
        public readonly string key = "This is my private key";
        private static string ApiTitle = "Area57";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        //ConfigureDevelop
        public IConfiguration Configuration { get; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var builder = services.AddMvcCore();

            builder.AddAuthorization();
            
            builder.AddFormatterMappings();
            builder.AddCors();
            services.AddMvcCore().AddApiExplorer();
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x=>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(key)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            })
            ;

            services.AddOptions();
            //services.ConfigureOptions(Configuration);
            services.Configure<ConnectionConfig>(Configuration.GetSection("DbSettings"))
              .AddTransient(cfg => cfg.GetService<IOptions<ConnectionConfig>>().Value);
            services.AddSingleton(new ResourceManager(typeof(Item)));
            
            services.AddSingleton<IJwtAuthenticationManager>(new JwtAuthenticationManager(key));
            services.TryAddSingleton<ISqlPolicyRegistry, SqlPolicyRegistry>();
            services.TryAddScoped<SqlDataConnection>();
            services.AddTransient<IDbContext, DbContext>();
            services.AddScoped<IItemService, ItemService>();
            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen();

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory, Microsoft.Extensions.Hosting.IHostApplicationLifetime appLifetime)
        {
            

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }

}

