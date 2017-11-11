using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System.Net.Http;

namespace AspNetCore20Example.Services.API.Integration.Tests
{
    public class Environment
    {
        public static TestServer Server { get; set; }
        public static HttpClient Client { get; set; }

        //private static ApplicationDbContext _context;

        public static void CriarServidor()
        {
            Server = new TestServer(
                WebHost.CreateDefaultBuilder()
                    .UseEnvironment("Testing")
                    .UseStartup<Startup>());

            //_context = Server.Host.Services.GetService(typeof(ApplicationDbContext)) as ApplicationDbContext;
            Client = Server.CreateClient();
        }
    }
}