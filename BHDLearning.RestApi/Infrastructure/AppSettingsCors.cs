using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDLearning.RestApi.Infrastructure
{
    public class AppSettingsCors
    {
        public string[] Methods { get; set; }
        public string[] Sites { get; set; }
        public string[] Headers { get; set; }
    }
}
