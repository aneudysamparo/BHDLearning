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
        private DbSetData dbSetData;
        public QueryListProducts()
        {
            //TODO DI
            dbSetData = new DbSetData();
            
        }

        protected override IEnumerable<Product> OnQuery(Func<Product, bool> filter = null)
        {
            return dbSetData.ListProducts(filter);

        }
    }
}
