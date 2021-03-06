﻿using BHDLearning.Data.Models;
using BHDLearning.DependencyInjection.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BHDLearning.Data
{
    [Inject]
    public class DbSetData
    {
        [Autowired]
        private ContextData contextData;

        public DbSetData()
        {
            //TODO: DI
            
        }

        public IEnumerable<ProductType> ListTypes(Func<ProductType, bool> filter = null)
        {
            IEnumerable<ProductType> items = contextData.ProductTypes;
            if (filter != null)
                items = items.Where(filter);

            return items;
        }

        public IEnumerable<Product> ListProducts(Func<Product, bool> filter = null)
        {
            IEnumerable<Product> items = contextData.Products;
            if (filter != null)
                items = items.Where(filter);

            return items;
        }

    }
}
