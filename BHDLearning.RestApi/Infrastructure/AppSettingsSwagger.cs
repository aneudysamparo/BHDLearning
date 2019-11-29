using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDLearning.RestApi.Infrastructure
{
    public class AppSettingsSwagger
    {
        public string Version
        {
            get
            {
                return $"v{MajorVersion}.{MinorVersion}";
            }
        }
        public int MajorVersion { get; set; }
        public int MinorVersion { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string VirtualDirectory { get; set; }
        public string Route { get; set; }


        public override string ToString()
        {
            return $"{VirtualDirectory}{Route.Format(Version, Title, Description)}";
        }

        public bool IsNull()
        {
            return MinorVersion == 0
                && MajorVersion == 0
                && Title.IsNullOrEmpty()
                && Description.IsNullOrEmpty()
                && VirtualDirectory.IsNullOrEmpty()
                && Route.IsNullOrEmpty();
        }
    }
}
