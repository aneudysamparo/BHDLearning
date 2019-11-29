using BHDLearning.RestApi.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class SwaggerExtension
    {
        public static IServiceCollection RestApiSwagger(this IServiceCollection services,
            IConfiguration configuration)
        {
            List<AppSettingsSwagger> appSettingsSwagger = new List<AppSettingsSwagger>();
            configuration.GetSection("AppSettingsSwagger").Bind(appSettingsSwagger);

            if (appSettingsSwagger.Count > 0)
            {
                services.AddApiVersioning(v =>
                {
                    v.DefaultApiVersion = new ApiVersion(appSettingsSwagger[0].MajorVersion, appSettingsSwagger[0].MinorVersion);
                    v.AssumeDefaultVersionWhenUnspecified = true;
                    v.ApiVersionReader = new MediaTypeApiVersionReader();
                });

                services.AddSingleton(appSettingsSwagger);
                services.AddSwaggerGen(configure =>
                {
                    foreach (AppSettingsSwagger appSettings in appSettingsSwagger)
                    {
                        configure.SwaggerDoc(appSettings.Version, new OpenApiInfo
                        {
                            Title = appSettings.Title,
                            Version = appSettings.Version,
                            Description = appSettings.Description
                        });
                    }
                    configure.DocInclusionPredicate((docName, apiDesc) =>
                    {
                        var actionApiVersionModel = apiDesc.ActionDescriptor?.GetApiVersion();
                        if (actionApiVersionModel == null)
                            return true;
                        if (actionApiVersionModel.DeclaredApiVersions.Any())
                            return actionApiVersionModel.DeclaredApiVersions.Any(v => $"v{v.ToString()}" == docName);

                        return actionApiVersionModel.ImplementedApiVersions.Any(v => $"v{v.ToString()}" == docName);
                    });
                });
            }

            return services;
        }

        public static IApplicationBuilder UseRestApiSwagger(this IApplicationBuilder app)
        {
            List<AppSettingsSwagger> appSettingsSwagger =
                app.ApplicationServices.GetService<List<AppSettingsSwagger>>();

            if (appSettingsSwagger != null && appSettingsSwagger.Count > 0)
            {
                app.UseSwagger();
                app.UseSwaggerUI(route =>
                {
                    foreach (AppSettingsSwagger appSettingSwagger in appSettingsSwagger)
                    {
                        route.SwaggerEndpoint(appSettingSwagger.ToString(), appSettingSwagger.Title);
                    }
                });
            }
            return app;
        }
    }
}
