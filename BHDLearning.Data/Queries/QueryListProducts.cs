using BHDLearning.Data.Infrastructure;
using BHDLearning.Data.Models;
using BHDLearning.DependencyInjection.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHDLearning.Data.Queries
{
    [Inject]
    public class QueryListProducts
        : QueryBase<Product>
    {
        private DbSetData dbSetData;
        public QueryListProducts(DbSetData dbSetData)
        {
            //TODO DI
            this.dbSetData = dbSetData;
            
        }

        protected override IEnumerable<Product> OnQuery(Func<Product, bool> filter = null)
        {
            return dbSetData.ListProducts(filter);

        }
    }
}
