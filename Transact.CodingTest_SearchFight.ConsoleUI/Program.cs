using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO;
using System.Threading.Tasks;
using Transact.CodingTest_SearchFight.ConsoleUI.Extensions;

namespace Transact.CodingTest_SearchFight.ConsoleUI
{
    class Program
    {
        /// <summary>
        /// Execute application
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            var configuration = BuildConfiguration(args);
            var host = CreateHostBuilder(args, configuration).Build();
            var app = ActivatorUtilities.CreateInstance<SearchFight>(host.Services);
            await app.RunAsync();
        }

        /// <summary>
        /// Setup configuration builder
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
        static IConfiguration BuildConfiguration(string[] args)
        {
            return new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables()
                .AddCommandLine(args)
                .Build();
        }

        /// <summary>
        /// Register services to the app
        /// </summary>
        /// <param name="args"></param>
        /// <param name="configuration"></param>
        /// <returns></returns>
        static IHostBuilder CreateHostBuilder(string[] args, IConfiguration configuration) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((context, services) =>
                    services.AddConfiguration(configuration)
                        .AddRepository()
                        .AddServices()
            );
    }
}
