using BHDLearning.RestApi.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHDLearning.Test
{
    public class TestStartup
        : ApiStartupBase
    {
        public TestStartup()
            : base()
        {
        }

        public override void OnConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            
        }

        public override void OnConfigureService(IServiceCollection services)
        {
            
        }
    }
}
