using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.RepoMongo.Infrastrucutre
{
    public class MongoDbConfigOptions
    {
        public string ConnectionString { get; set; }

        public string DatabaseName { get; set; }
    }
}
