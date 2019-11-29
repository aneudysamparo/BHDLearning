using BHDLearning.RestApi.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace BHDLeonLearning.Testing.Infrastructure
{
    public abstract class UnitTestBase<T>
        where T: ApiStartupBase
    {
        protected TestServer testServer;
        protected HttpClient client;

        public UnitTestBase()
        {
            testServer = new TestServer(GetHost());
            client = testServer.CreateClient();
        }

        protected virtual IWebHostBuilder GetHost()
        {
            return new WebHostBuilder()
                .UseEnvironment("Development")
                .UseStartup<T>();
        }
    }
}
