using BlackFraud.Application;
using BlackFraud.Application.WebSelenium.Infrastrucutre;
using BlackFraud.Application.WebSelenium.Lookups;
using BlackFraud.DI;
using BlackFraud.Domain.Behaviors;
using BlackFraud.Domain.Commands;
using BlackFraud.RepoMongo;
using BlackFraud.RepoMongo.Infrastrucutre;
using BlackFraud.RepoMongo.Persisters;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Batch.Infrastrucutre
{
    public static class Bootstrap
    {
        internal static Dictionary<string, string> ParseArgs(string[] args)
        {
            var arDic = new Dictionary<string, string>();
            for (int i = 0; i < args.Length; i += 2)
            {
                arDic.Add(args[i], args[i + 1]);
            }

            return arDic;
        }

        internal static void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            #region Db
            services.AddSingleton<MongoDbConfig>();
            #endregion Db

            #region Persisters and Lookups
            services.AddScoped<IVendorProductPersister, MongoVendorProductPersister>();
            services.AddScoped<IWebVendorProductLookup, SeleniumWebVendorProductLookup>();
            #endregion Persisters and Lookups

            #region Handlers
            services.AddTransient<IHandler<ProcessProductRequest, ProcessProductResponse>, ProcessProductHandler>();
            #endregion Handlers

            #region Options
            services.Configure<SeleniumConfiguration>(opts =>
            {
                opts.ChromePath = configuration["Selenium:ChromePath"];
                opts.FirefoxPath = configuration["Selenium:FirefoxPath"];
                opts.Timeout = configuration.GetValue<int>("Selenium:Timeout");
            });

            services.Configure<MongoDbConfigOptions>(opts =>
            {
                opts.ConnectionString = configuration["MongoBlackFraud:Connection"];
                opts.DatabaseName = configuration["MongoBlackFraud:Database"];
            });
            #endregion Options
        }
    }
}
