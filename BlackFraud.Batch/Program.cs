using BlackFraud.Batch.Infrastrucutre;
using BlackFraud.DI;
using BlackFraud.Domain.Behaviors;
using BlackFraud.Domain.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Batch
{
    class Program
    {
        public static IConfiguration Configuration { get; private set; }

        public static IServiceProvider ServiceProvider { get; private set; }

        static readonly string ENV_NAME = "Development";

        static void Main(string[] args)
        {
            Console.WriteLine("Carregando configurações...");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{ENV_NAME}.json", optional: true, reloadOnChange: true)
                .AddJsonFile("secrets.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables("APP")
                .AddXmlFile("app.config", optional: true);

            Configuration = builder.Build();

            //setup our DI
            var svcColl = new ServiceCollection();

            ConfigureServices(svcColl, Configuration);

            ServiceProvider = svcColl.BuildServiceProvider(validateScopes: false);

            Process();

            Console.ReadKey();
        }

        static void Process()
        {
            using (var scope = ServiceProvider.CreateScope())
            {
                var handler = ServiceProvider.GetService<IHandler<ProcessProductRequest, ProcessProductResponse>>();

                var rs = handler.Handle(new ProcessProductRequest
                {
                    Browser = Domain.Infrastrucuture.Browsers.Firefox,
                    Timeout = TimeSpan.FromMinutes(2),
                    Url = new Uri("https://www.submarino.com.br/produto/126831715"),
                    Vendor = "Americanas"
                });

                Console.WriteLine(JsonConvert.SerializeObject(rs));
            }
        }

        static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            #region Logs
            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));

            services.AddLogging(cfg => cfg.AddConsole());
            #endregion Log s

            Bootstrap.Initialize(services, Configuration);
        }
    }
}
