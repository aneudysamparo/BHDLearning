using BHDLearning.Data.Infrastructure;
using BHDLearning.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHDLearning.Data.Queries
{
    public class QueryListTypes
        : QueryBase<ProductType>
    {
        private ServiceData serviceData;
        public QueryListTypes()
        {
            serviceData = new ServiceData();
            
        }

        protected override IEnumerable<ProductType> OnQuery(Func<ProductType, bool> filter = null)
        {
            return serviceData.ListTypes(filter);

        }
    }
}
