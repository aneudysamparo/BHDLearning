using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        internal static IServiceProvider serviceProvider;

        public static IApplicationBuilder UseDependency(this IApplicationBuilder app)
        {
            serviceProvider = app.ApplicationServices;
            return app;
        }

        public static T GetService<T>(this AppDomain appDomain, bool throwExceptionIfNoRegister = false)
        {
            T service = default;
            if (serviceProvider.IsRegister(typeof(T)))
            {
                service = serviceProvider.GetService<T>();
            }
            else if (serviceProvider.CreateScope().ServiceProvider.IsRegister(typeof(T)))
            {
                service = serviceProvider.CreateScope().ServiceProvider.GetService<T>();
            }
            else
            {
                if (throwExceptionIfNoRegister && service == null)
                    throw new Exception($"el tipo {typeof(T).Name} no esta registrado en las dependencias");

            }

            return service;
        }

        public static bool IsRegister(this IServiceProvider serviceProvider, Type typeService)
        {
            bool isRegister = false;
            try
            {
                serviceProvider.GetService(typeService);
                isRegister = true;
            }
            catch (InvalidOperationException)
            {
            }

            catch (Exception)
            {

                throw;
            }
            return isRegister;
        }
    }
}
