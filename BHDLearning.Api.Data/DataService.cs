using BHDLearning.Data.Models;
using BHDLearning.Data.Queries;
using BHDLearning.DependencyInjection.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDLearning.Api.Data
{
    [Inject]
    public class DataService
    {
        private QueryListTypes queryListTypes;
        private QueryListProducts queryListProducts;

        public DataService(QueryListTypes queryListTypes,
            QueryListProducts queryListProducts)
        {
            //TODO DI
            this.queryListProducts = queryListProducts;
            this.queryListTypes = queryListTypes;
        }

        public async Task<IEnumerable<ProductType>> GetTypes(string filter)
        {
            Func<ProductType, bool> lambdaFilter = null;

            if (!filter.IsNullOrEmpty())
                lambdaFilter = t => t.Title.ToLower().Contains(filter.ToLower());

            return queryListTypes.Query(lambdaFilter);
        }

        public async Task<IEnumerable<Product>> GetProducts(string filter)
        {
            Func<Product, bool> lambdaFilter = null;

            if (!filter.IsNullOrEmpty())
                lambdaFilter = p => p.Title.ToLower().Contains(filter.ToLower())
                 || p.Type.Title.ToLower().Contains(filter.ToLower());

            return queryListProducts.Query(lambdaFilter);
        }
    }
}
