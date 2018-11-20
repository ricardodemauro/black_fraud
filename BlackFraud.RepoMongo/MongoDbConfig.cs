using BlackFraud.Domain;
using BlackFraud.RepoMongo.Infrastrucutre;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace BlackFraud.RepoMongo
{
    public class MongoDbConfig
    {
        public IMongoDatabase Database { get; }

        public MongoClient Client { get; }

        public MongoDbConfig(IOptions<MongoDbConfigOptions> options)
        {
            var conn = options.Value.ConnectionString;
            var db = options.Value.DatabaseName;

            Client = new MongoClient(conn);
            Database = Client.GetDatabase(db);
        }
    }
}
