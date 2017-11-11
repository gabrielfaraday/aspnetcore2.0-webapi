using AspNetCore20Example.Infra.CrossCutting.Identity.Data;
using AspNetCore20Example.Infra.Data.Context;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace AspNetCore20Example.Services.API.Integration.Tests.Configuration
{
    [Collection("Base collection")]
    public abstract class BaseIntegrationTest
    {
        protected readonly TestServer Server;
        protected readonly HttpClient Client;
        protected readonly MainContext TestMainContext;
        protected readonly ApplicationDbContext TestApplicationDbContext;

        protected BaseTestFixture Fixture { get; }

        protected BaseIntegrationTest(BaseTestFixture fixture)
        {
            Fixture = fixture;

            TestMainContext = fixture.TestMainContext;
            TestApplicationDbContext = fixture.TestApplicationDbContext;
            Server = fixture.Server;
            Client = fixture.Client;

            ClearDb().Wait();
        }

        private async Task ClearDb()
        {
            var commands = new[]
            {
                "EXEC sp_MSForEachTable 'ALTER TABLE ? NOCHECK CONSTRAINT ALL'",
                "EXEC sp_MSForEachTable 'SET QUOTED_IDENTIFIER ON; DELETE FROM ?'",
                "EXEC sp_MSForEachTable 'ALTER TABLE ? CHECK CONSTRAINT ALL'"
            };

            await TestMainContext.Database.OpenConnectionAsync();

            foreach (var command in commands)
            {
                await TestMainContext.Database.ExecuteSqlCommandAsync(command);
            }

            TestMainContext.Database.CloseConnection();
        }
    }
}