using System;
using System.Collections.Generic;
using System.Text;

namespace BHDLearning.Data.Models
{
    public class Product
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public ProductType Type { get; set; }
    }
}
