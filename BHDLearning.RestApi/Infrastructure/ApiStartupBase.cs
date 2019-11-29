using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDLearning.RestApi.Infrastructure
{
    public abstract class ApiStartupBase
    {
        public IConfiguration Configuration { get; set; }

        protected ApiStartupBase()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }

        public void ConfigureServices(IServiceCollection services)
        {

            OnConfigureService(services);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            OnConfigure(app, env);
        }

        public abstract void OnConfigureService(IServiceCollection services);
        public abstract void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env);
    }
}
