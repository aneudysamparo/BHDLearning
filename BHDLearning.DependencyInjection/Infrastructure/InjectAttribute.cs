using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BHDLearning.DependencyInjection.Infrastructure
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class InjectAttribute
        : Attribute
    {
        public ServiceLifetime Lifetime { get; set; } 
                = ServiceLifetime.Transient;

        public Type TypeService { get; set; }

    }
}
