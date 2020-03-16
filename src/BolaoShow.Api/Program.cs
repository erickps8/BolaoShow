using BolaoShow.Data.Context;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using BolaoShow.Api.Configuration;
using Microsoft.AspNetCore;
using BolaoShow.Api.Data;

namespace BolaoShow.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                .Build()
                .CreateDatabase<ApplicationDbContext>()
                .CreateDatabase<Contexto>()
                .Run();
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
          WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
