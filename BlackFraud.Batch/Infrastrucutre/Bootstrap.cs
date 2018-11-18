using BlackFraud.DI;
using BlackFraud.Domain.Behaviors;
using BlackFraud.Domain.Commands;
using BlackFraud.RepoMongo.Persisters;
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

        internal static void Initialize(IServiceCollection services)
        {
            #region Db
            services.AddSingleton<IVendorProductPersister, MongoVendorProductPersister>();
            #endregion Db

            #region Handlers
            services.AddTransient<IHandler<ProcessProductRequest, ProcessProductResponse>, ProcessProductResponse>();
            #endregion Handlers
        }
    }
}
