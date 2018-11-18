using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Domain.Commands
{
    public class ProcessProductRequest
    {
        public string Vendor { get; set; }

        public string Browser { get; set; }

        public Uri Url { get; set; }

        public TimeSpan Timeout { get; set; }
    }
}
