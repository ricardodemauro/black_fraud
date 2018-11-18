using BlackFraud.Domain.Behaviors;
using BlackFraud.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.RepoMongo.Persisters
{
    public class MongoVendorProductPersister : IVendorProductPersister
    {
        private readonly string _collectionName = "VendorProduct";

        private readonly MongoDbConfig _mongoDbConfig;

        public MongoVendorProductPersister(MongoDbConfig mongoDbConfig)
        {
            _mongoDbConfig = mongoDbConfig;
        }

        public void AddVendorProduct(VendorProduct vendorProduct)
        {
            var coll = _mongoDbConfig.Database.GetCollection<VendorProduct>(_collectionName);

            coll.InsertOne(vendorProduct);
        }
    }
}
