using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Repository.MariaDb.Insfrastructure
{
    public static class MariaDbEventCodes
    {
        internal static readonly EventId DbAddingWebProduct = new EventId(201, nameof(DbAddingWebProduct));
    }
}
