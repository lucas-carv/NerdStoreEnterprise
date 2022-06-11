using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using NSE.Identidade.API.Configuration;
using NSE.Identidade.API.Data;
using NSE.Identidade.API.Extensions;
using System;
using System.Text;

namespace NSE.Identidade.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IHostEnvironment hostEnvironment)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(hostEnvironment.ContentRootPath) // descobre o arquivo a configuracao
                .AddJsonFile("appsettings.json", true, true) // adiciona o arquivo appssetings.json
                .AddJsonFile($"appsettings.{hostEnvironment.EnvironmentName}.json", true, true) // adiciona o arquivo appssetingsdevelopment.json
                .AddEnvironmentVariables();

            if (hostEnvironment.IsDevelopment())
            {
                builder.AddUserSecrets<Startup>();
            }

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentityConfiguration(Configuration);
            
            services.AddApiConfiguration();

            services.AddSwaggerConfiguration();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwaggerConfiguration();

            app.UseApiConfiguration(env);
        }
    }
}
