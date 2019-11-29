using BHDLearning.Data.Models;
using BHDLearning.Data.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BHDLearning.Api.Data
{
    public class DataService
    {
        private QueryListTypes queryListTypes;
        private QueryListProducts queryListProducts;

        public DataService()
        {
            //TODO DI
            queryListProducts = new QueryListProducts();
            queryListTypes = new QueryListTypes();
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
