using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Domain.Infrastrucuture
{
    public abstract class ModelBase
    {
        public string Id { get; set; }
    }
}
