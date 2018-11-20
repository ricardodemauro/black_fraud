using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Application.Infrastrucure
{
    public static class LoggerCodes
    {
        internal static readonly EventId InitProcessProduct = new EventId(100, nameof(InitProcessProduct));
    }
}
