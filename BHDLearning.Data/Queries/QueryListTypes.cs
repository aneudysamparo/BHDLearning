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
    public class QueryListTypes
        : QueryBase<ProductType>
    {
        private DbSetData dbSetData;
        public QueryListTypes(DbSetData dbSetData)
        {
            //TODO DI
            this.dbSetData = dbSetData;

        }

        protected override IEnumerable<ProductType> OnQuery(Func<ProductType, bool> filter = null)
        {
            return dbSetData.ListTypes(filter);

        }
    }
}
