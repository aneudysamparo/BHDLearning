using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace System.Reflection
{
    public static class ReflectionExtension
    {
        public static string GetFileNameFromPath(this string path)
        {
            return Path.GetFileName(path);
        }

        public static IEnumerable<Assembly> GetReferenceAssemblies(this AppDomain appDomain)
        {
            List<Assembly> referenceAssemblies = AppDomain.CurrentDomain.GetAssemblies()
                .Where(a => !a.IsDynamic && !a.FullName.StartsWith("Microsoft") && !a.FullName.StartsWith("System")).ToList();

            Directory.GetFiles(appDomain.BaseDirectory, "*.dll",
                SearchOption.TopDirectoryOnly)
                .Where(f => !f.GetFileNameFromPath().StartsWith("Microsoft") && !f.GetFileNameFromPath().StartsWith("System"))
                .ToList()
                .ForEach(fileAssembly =>
                {
                    Assembly assemblyBin = Assembly.LoadFrom(fileAssembly);
                    if (!referenceAssemblies.Contains(assemblyBin))
                        referenceAssemblies.Add(assemblyBin);
                });

            return referenceAssemblies;
        }
    }
}
