using BHDLearning.Data;
using BHDLearning.Data.Queries;
using BHDLearning.Testing.Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BHDLearning.Test.Calculator
{
    [TestClass]
    public class DataUnitTest
        : UnitTestBase<TestStartup>
    {
        private QueryListTypes queryListTypes;
        private QueryListProducts queryListProducts;

        public DataUnitTest()
            : base()
        {
            queryListTypes = new QueryListTypes();
            queryListProducts = new QueryListProducts();
        }
        [TestMethod]
        public void ListTypes()
        {
            int count = 0;
            var items = queryListTypes.Query(callBack: i => count = i.Count());
            Assert.AreEqual(count, 4);
        }

        [TestMethod]
        public void ListProducts()
        {
            int count = 0;
            var items = queryListProducts.Query(callBack: i => count = i.Count());
            Assert.AreEqual(count, 22);
        }
    }
}
