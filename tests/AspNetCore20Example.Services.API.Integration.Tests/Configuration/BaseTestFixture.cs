using AspNetCore20Example.Infra.CrossCutting.Identity.Data;
using AspNetCore20Example.Infra.Data.Context;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net.Http;

namespace AspNetCore20Example.Services.API.Integration.Tests.Configuration
{
    public class BaseTestFixture : IDisposable
    {
        public readonly TestServer Server;
        public readonly HttpClient Client;
        public readonly MainContext TestMainContext;
        public readonly ApplicationDbContext TestApplicationDbContext;

        public BaseTestFixture()
        {
            Server = new TestServer(
                WebHost.CreateDefaultBuilder()
                    .UseEnvironment("Testing")
                    .UseStartup<Startup>());

            TestApplicationDbContext = Server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            TestMainContext = Server.Host.Services.GetService(typeof(MainContext)) as MainContext;

            Client = Server.CreateClient();

            SetupDatabase();
        }

        private void SetupDatabase()
        {
            try
            {
                TestApplicationDbContext.Database.EnsureCreated();
                TestMainContext.Database.Migrate();
            }
            catch (Exception ex)
            {
                //TODO: Add a better logging
                // Does nothing
            }
        }

        public void Dispose()
        {
            TestApplicationDbContext.Dispose();
            TestMainContext.Dispose();
            Client.Dispose();
            Server.Dispose();
        }
    }
}