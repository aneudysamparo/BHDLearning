using BHDLearning.Data.Models;
using BHDLearning.DependencyInjection.Infrastructure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace BHDLearning.Data
{
    [Inject]
    public class ContextData
    {
        public ContextData()
        {
            using (StreamReader r = new StreamReader("Data.json"))
            {
                string json = r.ReadToEnd();
                Products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                ProductTypes = Products.Select(p => p.Type).GroupBy(t => t.Title).Select(t => t.First());
            }
            

        }
        public IEnumerable<Product> Products { get; set; }
        public IEnumerable<ProductType> ProductTypes { get; set; }
    }
}
