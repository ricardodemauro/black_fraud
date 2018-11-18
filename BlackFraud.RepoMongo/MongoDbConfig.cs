using BlackFraud.Domain;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.RepoMongo
{
    public class MongoDbConfig : DbBase
    {
        private readonly string _connectionString;

        public IMongoDatabase Database { get; }

        public MongoClient Client { get; }

        public MongoDbConfig(IConfiguration configuration)
            : this("blackFraud", configuration)
        {

        }

        public MongoDbConfig(string name, IConfiguration configuration) : base(name)
        {
            var section = configuration.GetSection($"Mongo{name}");
            var conn = section["Connection"];
            var db = section["Database"];

            Client = new MongoClient(conn);
            Database = Client.GetDatabase(db);
        }
    }
}
