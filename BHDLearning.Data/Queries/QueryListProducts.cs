using BHDLearning.Data.Infrastructure;
using BHDLearning.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHDLearning.Data.Queries
{
    public class QueryListProducts
        : QueryBase<Product>
    {
        private ServiceData serviceData;
        public QueryListProducts()
        {
            serviceData = new ServiceData();
            
        }

        protected override IEnumerable<Product> OnQuery(Func<Product, bool> filter = null)
        {
            return serviceData.ListProducts(filter);

        }
    }
}
