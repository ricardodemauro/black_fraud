using BlackFraud.Domain.Infrastrucuture;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlackFraud.Domain.Models
{
    public class Product : ModelBase
    {
        public string DisplayName { get; set; }

        public string Code { get; set; }

        public Uri Url { get; set; }

        public string VendorCode { get; set; }
    }
}
