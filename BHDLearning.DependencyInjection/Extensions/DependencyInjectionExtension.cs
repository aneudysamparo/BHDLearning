using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;
using BHDLearning.DependencyInjection.Infrastructure;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyInjectionExtension
    {
        public static IServiceCollection AddInjection(this IServiceCollection services)
        {
            var injectTypes = AppDomain.CurrentDomain
                .GetReferenceAssemblies()
                .SelectMany(a => a.GetTypes().Where(t =>
                    !t.IsAbstract
                    && Attribute.IsDefined(
                        t, typeof(InjectAttribute))))
                .ToList();
                
            injectTypes.ForEach( typeService =>
                {
                    InjectAttribute injectAttribute =
                        typeService.GetCustomAttribute<InjectAttribute>();

                    Type typeInject = injectAttribute.TypeService ?? typeService;
                    ServiceDescriptor serviceDescriptor = new ServiceDescriptor(
                        typeInject, 
                        serviceProvider =>
                        {
                            return typeService.InstanceFromServiceProvider(serviceProvider);
                        }, injectAttribute.Lifetime);

                    services.Add(serviceDescriptor);
                });
            return services;
        }

        public static object InstanceFromServiceProvider(
            this Type injectService, IServiceProvider serviceProvider)
        {
            ConstructorInfo constructorInfo = injectService.GetConstructors()
                .FirstOrDefault();

            object[] constructorParameters = constructorInfo?.GetParameters()
                .Select(p => serviceProvider.GetService(p.ParameterType))
                .ToArray();

            return Activator.CreateInstance(injectService, constructorParameters)
                .LoadAutowired(serviceProvider);
        }
        public static object LoadAutowired(this object instance, IServiceProvider serviceProvider)
        {
            List<MemberInfo> autowireMembers =
            instance.GetType()
                .GetMembers(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance)
                .Where(m => (m.MemberType == MemberTypes.Field || m.MemberType == MemberTypes.Property)
                    && Attribute.IsDefined(m, typeof(AutowiredAttribute)))
                .ToList();

            autowireMembers.ForEach(m => m.SetValueFromServiceProvider(instance, serviceProvider));
            return instance;
        }
    }
}
