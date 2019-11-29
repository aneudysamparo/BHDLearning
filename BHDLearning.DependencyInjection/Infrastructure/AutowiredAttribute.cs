using System;
using System.Collections.Generic;
using System.Text;

namespace BHDLearning.DependencyInjection.Infrastructure
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false, Inherited = true)]
    public class AutowiredAttribute
        : Attribute
    {
    }
}
