using BHDLearning.RestApi.Infrastructure;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class CorsExtension
    {
        public static IServiceCollection RestApiCors(this IServiceCollection services,
            IConfiguration configuration)
        {
            AppSettingsCors appSettingsCors = new AppSettingsCors();
            configuration.GetSection("AppSettingsCors").Bind(appSettingsCors);
            services.AddCors(setupAction => setupAction.AddPolicy("AppSettingsCors", policy =>
            {
                if (appSettingsCors.Headers != null && appSettingsCors.Headers.Any())
                {
                    if (appSettingsCors.Headers.Contains("*"))
                    {
                        policy.AllowAnyHeader();
                    }
                    else
                    {
                        policy.WithHeaders(appSettingsCors.Headers);
                    }
                }

                if (appSettingsCors.Methods != null && appSettingsCors.Methods.Any())
                {
                    if (appSettingsCors.Methods.Contains("*"))
                    {
                        policy.AllowAnyMethod();
                    }
                    else
                    {
                        policy.WithMethods(appSettingsCors.Methods);
                    }
                }

                if (appSettingsCors.Sites != null && appSettingsCors.Sites.Any())
                {
                    if (appSettingsCors.Sites.Contains("*"))
                    {
                        policy.AllowAnyOrigin();
                    }
                    else
                    {
                        policy.WithOrigins(appSettingsCors.Sites);
                    }
                }
            }));
            return services;
        }
    }
}
