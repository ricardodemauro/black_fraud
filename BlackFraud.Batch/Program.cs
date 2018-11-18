using BlackFraud.Batch.Infrastrucutre;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
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

        public static IServiceCollection ServiceProvider { get; private set; }

        static readonly string ENV_NAME = "Development";

        static void Main(string[] args)
        {
            Console.WriteLine("Carregando configurações...");

            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json")
                .AddJsonFile($"appsettings.{ENV_NAME}.json")
                .AddEnvironmentVariables("APP")
                .AddXmlFile("app.config");

            Configuration = builder.Build();

            //setup our DI
            ServiceProvider = new ServiceCollection();

            Bootstrap.Initialize(ServiceProvider);

            Console.ReadKey();
        }
    }
}
