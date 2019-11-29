using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BHDLearning.RestApi.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace BHDLearning.Gateway
{
    public class Startup
        : ApiStartupBase
    {
        public Startup()
            : base()
        {
        }


        public override void OnConfigureService(IServiceCollection services)
        {
            services.AddApi(Configuration);
        }

        public override void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseApi(env);
        }
    }
}
